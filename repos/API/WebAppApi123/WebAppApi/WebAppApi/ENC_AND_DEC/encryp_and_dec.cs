using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAppApi.Model;

namespace WebAppApi.ENC_AND_DEC
{
    public class encryp_and_dec : Iencryp_and_dec
    {
        string connectionStrings = Startup.StaticConfiguration["demant:connectionString"];

        string FilePath = Startup.StaticConfiguration["demant:FilePath"];
        public Response Encrypt(depart enc)
        {
            Response res = new Response();
            try
            {


                string EncryptionKey = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                byte[] clearBytes = Encoding.Unicode.GetBytes(enc.password);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        enc.password = Convert.ToBase64String(ms.ToArray());
                    }

                }
                String query = "insert into depart_login_encry (email,username,password) values(@email,@username,@password )";


                NpgsqlConnection con = new NpgsqlConnection(connectionStrings);
                con.Open();


                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("@email", enc.email);
                cmd.Parameters.AddWithValue("@username", enc.username);
                cmd.Parameters.AddWithValue("@password", enc.password);
                cmd.CommandText = query;
                cmd.Connection = con;


                // email send

                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();


                msg.From = new MailAddress("amit.rai@cylsys.com");
                msg.To.Add(enc.email);
                msg.Subject = "leave";
                msg.CC.Add(enc.cc);
              //msg.Bcc.Add("amitkumarrai172001@gmail.com");

                //Fetching Email Body Text from EmailTemplate File.  
                // string FilePath = "C:\\Users\\Amit Rai\\source\\repos\\API\\WebAppApi123\\WebAppApi\\WebAppApi\\Templated\\Emailtemplate.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();
                msg.Body = MailText;
                
                /* msg.Body = "<!DOCTYPE html>" +
                             "<html>" +
                             "<head>" +
                             "<style>" +
                             "table, th, td {border:1px solid black;}" +
                             "border-collapse: collapse;"+
                 "</style>" +
                 "</head>" +
                             "<body>" +

                             "<h2>A basic HTML table</h2>" +

                             "<table style = width:100 %>" +
                             " <tr><th>Company" +
                             "<th>Contact</th>" +
                             "<th>Country</th>" +
                             "</tr> <tr>" +
                             "<td>Alfreds Futterkiste</td>" +
                             "<td>Maria Anders</td>" +
                             "<td>Germany</td>" +
                             "</tr>" +
                             " <tr>" +
                             "<td>Centro comercial Moctezuma</td>" +
                             "<td>Francisco Chang</td>" +
                             "<td>Mexico</td>" +
                             "</tr>" +
                             " </table>" +
                             "<p>To undestand the example better, we have added borders to the table.</p></body></html>";*/

                msg.IsBodyHtml = true;

                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("amit.rai@cylsys.com", "Password@2");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(msg);
                res.message = "Mail send successfully";



               




                var id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    res.status = true;
                    res.message = "data successfully inserted & Email has been sent";
                    res.email = enc.email;
                    res.username = enc.username;
                    res.password = enc.password;
                }
                else
                {
                    res.status = false;
                    res.message = "data not inserted";

                }
            }

            catch (Exception ex)
            {
                res.status = true;

                res.message = "exception error" + ex.Message;
            }


            return res;
        }


        public Response Decrypt(depart dec)
        {
            Response res = new Response();
            try
            {

                string EncryptionKey = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                dec.password = dec.password.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(dec.password);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        dec.password = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }

                String query = "insert into depart_login_dec (email,username,password) values(@email,@username,@password )";


                NpgsqlConnection con = new NpgsqlConnection(connectionStrings);
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
               cmd.Parameters.AddWithValue("@email", dec.email);
                cmd.Parameters.AddWithValue("@username", dec.username);
                cmd.Parameters.AddWithValue("@password", dec.password);
                cmd.CommandText = query;
                cmd.Connection = con;

                var id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    res.status = true;
                    res.message = "password access";
                   res.email = dec.email;
                    res.username = dec.username;
                    res.password = dec.password;


                }
                else
                {
                    res.status = false;
                    res.message = "password not access";

                }
            }

            catch (Exception ex)
            {
                res.status = true;

                res.message = "exception error" + ex.Message;
            }


            return res;
        }
    }
}
