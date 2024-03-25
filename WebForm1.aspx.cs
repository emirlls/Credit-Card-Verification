using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDersi1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public event EventHandler TextChanged;

        static string[] errorMessages = {
        "Lütfen tüm kart bilgilerini doldurun",
        "Kart numarası eksik veya yanlış formatta",
        "Kart sahibi ismi yanlış formatta",
        "Ay/Yıl bilgisi yanlış veya eksik formatta",
        "CVV eksik veya yanlış formatta"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
       
        }


        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            Dogrula();
        }

        private void Dogrula()
        {
            
            bool cardNumberValid = false;
            bool cardNameValid = false;
            bool expirationDateValid = false;
            bool cvvValid = false;

            if (string.IsNullOrWhiteSpace(cardnumber.Text) || string.IsNullOrWhiteSpace(cardname.Text) || string.IsNullOrWhiteSpace(exdate.Text) || string.IsNullOrWhiteSpace(cvv.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[0] + "');", true);
                return;

            }

            if (string.IsNullOrWhiteSpace(cardnumber.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[1] + "');", true);

            }
            else
            {
                if (ValidateCardNumber(cardnumber.Text)) {
                    cardNumberValid = true;
                }
                else
                {
                    cardNumberValid = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[1] + "');", true);
                }                
                
            }

            if (string.IsNullOrWhiteSpace(cardname.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[2] + "');", true);

            }
            else
            {
                if(ValidateCardName(cardname.Text)) {   cardNameValid = true; }
                else { 
                    cardNameValid = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[2] + "');", true);
                }
            }


            if (string.IsNullOrWhiteSpace(exdate.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[3] + "');", true);

            }
            else
            {
                if (ValidateExpirationDate(exdate.Text))
                {
                    expirationDateValid = true;
                }
                else {  
                    expirationDateValid = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[3] + "');", true);
                }
            }



            if (string.IsNullOrWhiteSpace(cvv.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[4] + "');", true);

            }
            else
            {
                if(ValidateCVV(cvv.Text)) {cvvValid = true; }
                else { 
                    cvvValid= false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + errorMessages[4] + "');", true);
                }
            }



            // Tüm doğrulama işlemleri başarılı ise mesajı göster
            if (cardNumberValid && cardNameValid && expirationDateValid && cvvValid)
            {
                Response.Write("<script>alert('Kredi kartı doğrulandı. İşlemlere devam edebilirsiniz');</script>");
                cardnumber.Text = "";
                cardname.Text = "";
                exdate.Text = "";
                cvv.Text = "";
            }
        }
        // Kart logosunu doğrulayan fonksiyon

        //protected void logo()
        //{
        //    string firstSixDigits = cardnumber.Text.Substring(0, 6);
        //    string firstTwoDigits = cardnumber.Text.Substring(0, 2);
        //    string firstdigit = cardnumber.Text.Substring(0, 1);

        //    // Mastercard numarası olduğunu kontrol et
        //    if ((firstTwoDigits == "52" || firstTwoDigits == "53" || firstTwoDigits == "54" || firstTwoDigits == "55") || (firstSixDigits.CompareTo("222100") >= 0 && firstSixDigits.CompareTo("272099") <= 0))
        //    {
        //        mastercardImage.Visible = true; // Mastercard resmini görünür yap
        //    }
        //    else
        //    {
        //        mastercardImage.Visible = false; // Mastercard resmini görünmez yap
        //    }
        //    if (firstdigit == "4")
        //    {
        //        visaImage.Visible = true;
        //    }
        //    else
        //    {
        //        visaImage.Visible = false;
        //    }

        //}

        // Kart numarasını doğrulayan fonksiyon

        private bool ValidateCardNumber(string cardNumber)
        {        
            if (cardNumber.Length == 19)
            {
                if (cardNumber.Contains(" "))
                {
                    string[] parts = cardNumber.Split(' ');
                    if (parts.Length == 4)
                    {
                        string first = parts[0];
                        string second = parts[1];
                        string third = parts[2];
                        string fourth = parts[3];
                        if (!IsNumeric(first))
                        {

                            return false; 

                        }
                        if (!IsNumeric(second))
                        {

                            return false; 
                        }
                        if (!IsNumeric(third))
                        {

                            return false; 
                        }
                        if (!IsNumeric(fourth))
                        {
   
                            return false; 
                        }
                        return true;
                    }
                    else { return false; }
                }
                else { return false;}
            }
            else{return false;}
        }

        // Kart sahibi adını doğrulayan fonksiyon
        private bool ValidateCardName(string cardName)
        {
            if (string.IsNullOrWhiteSpace(cardName))
            {
                return false;
            }
            else
            {
                if(cardName.Contains(" "))
                {
                    string[] parts = cardName.Split(' ');
                    for (int i = 0; i < parts.Length; i++) {
                        if (IsAlphabetic(parts[i])) {  
                            return true; 
                        }
                        else { 
                            return false; 
                        }
                    }
                    return true;
                }
                else { 
                    return false; 
                }
                
            }

        }

        // Kart son kullanım tarihini doğrulayan fonksiyon

        private bool ValidateExpirationDate(string expirationDate)
        {
            if (string.IsNullOrWhiteSpace(expirationDate))
            {

                return false;
            }
            else
            {
                // Eğer son kullanma tarihi alanı doluysa kontrol et
                if (expirationDate.Length == 5)
                {
                    string[] parts = expirationDate.Split('/');


                    // Ay ve yılın sadece rakamlardan oluşup oluşmadığını kontrol et
                    if (IsNumeric(parts[0]) && IsNumeric(parts[1]))
                    {
                        int month = int.Parse(parts[0]);
                        int year = int.Parse(parts[1]);

                        // Ay değerinin 12'den büyük olup olmadığını kontrol et
                        if (month > 12)
                        {
                            // Eğer ay değeri 12'den büyükse uyarı ver ve false döndür

                            return false;
                        }

                        // Yıl değerinin 24'ten küçük olup olmadığını kontrol et
                        if (year < 24)
                        {
                            // Eğer yıl değeri 24'ten küçükse uyarı ver ve false döndür

                            return false;
                        }
                        return true;
                        // Tüm kontrollerden geçildiyse, son kullanma tarihi geçerlidir                      
                    }
                    else
                    {
                        // Eğer ay ve yıl rakamlardan oluşmuyorsa uyarı ver ve false döndür

                        return false;
                    }
                }
                else
                {
                    // Eğer son kullanma tarihi alanı 5 karakterden farklıysa uyarı ver ve false döndür

                    return false;
                }
            }
        }


       // CVV'yi doğrulayan fonksiyon
        private bool ValidateCVV(string cvv)
        {
            if (string.IsNullOrWhiteSpace(cvv)) { return false; }
            else
            {
                if (cvv.Length == 3)
                {
                    if (IsNumeric(cvv)) { return true; }
                    else { return false; }
                }
                else { return false; }
            }

        }

        // Verilen metnin sadece rakamlardan oluşup oluşmadığını kontrol eden yardımcı fonksiyon
        private static bool IsNumeric(string value)
        {
            return value.All(char.IsDigit);
        }

        // Verilen metnin sadece harflerden oluşup oluşmadığını kontrol eden yardımcı fonksiyon
        private static bool IsAlphabetic(string value)
        {
            return value.All(char.IsLetter);
        }

    }
}