
// Kart numarası alanını biçimlendirme fonksiyonu
function formatCardNumber(cardNumberField) {
    var cardNumberValue = cardNumberField.value.replace(/\D/g, ''); // Sadece rakamları al

    // En fazla 16 hane girilebilir
    cardNumberValue = cardNumberValue.substring(0, 16);

    // Her 4 rakamdan sonra bir boşluk ekleyerek biçimlendir
    cardNumberValue = cardNumberValue.replace(/(\d{4})(?=\d)/g, '$1 ');

    cardNumberField.value = cardNumberValue;

    // SHOW IMAGE
    var firstDigit = cardNumberField.value.charAt(0);
    var secondDigit = cardNumberField.value.charAt(1);

    // Visa ve Mastercard resimlerini görünmez yap
    document.getElementById("visaImage").style.display = "none";
    document.getElementById("mastercardImage").style.display = "none";

    showCardImage(cardNumberField);

    //// Kart numarasının ilk hanesine göre resimleri görünür yap
    //if (firstDigit === '4') {
    //    document.getElementById("visaImage").style.display = "inline";
    //} else if (firstDigit === '5') {
    //    if (secondDigit === '2' || secondDigit === '3' || secondDigit === '4' || secondDigit === '5') {
    //        document.getElementById("mastercardImage").style.display = "inline";
    //    }       
    //}
}

function validateCardHolderName() {
    var cardHolderNameField = document.getElementById('cardname');
    var cardHolderNameValue = cardHolderNameField.value.replace(/[^a-zA-Z\s]/g, ''); // Sadece harfleri ve boşlukları al
    cardHolderNameField.value = cardHolderNameValue;
}


// Expiration date alanını biçimlendirme fonksiyonu
function formatExpirationDate(expirationDateField) {
    var expirationDateValue = expirationDateField.value.replace(/\D/g, ''); // Sadece rakamları al

    // MM/YY formatında biçimlendir
    if (expirationDateValue.length > 2) {
        expirationDateValue = expirationDateValue.substr(0, 2) + '/' + expirationDateValue.substr(2);
    }

    // En fazla 5 karakter (2 haneli ay ve 2 haneli yıl + '/' karakteri) kabul edilir
    expirationDateValue = expirationDateValue.substring(0, 5);

    expirationDateField.value = expirationDateValue;
}

// CVV alanını kontrol etme fonksiyonu
function validateCVV(cvvField) {

    var cvvValue = cvvField.value.replace(/\D/g, ''); // Sadece rakamları al

    // Maximum 3 hane girilebilir
    if (cvvValue.length > 3) {
        cvvValue = cvvValue.substr(0, 3);
    }

    cvvField.value = cvvValue;
}


function showCardImage(input) {
    // Kart numarasının ilk hanesini al
    var firstDigit = input.value.charAt(0);
    var secondDigit = input.value.charAt(1);
    // Visa ve Mastercard resimlerini görünmez yap
    document.getElementById("visaImage").style.display = "none";
    document.getElementById("mastercardImage").style.display = "none";
    
    // Kart numarasının ilk hanesine göre resimleri görünür yap
    if (firstDigit === '4') {
        document.getElementById("visaImage").style.display = "inline";
    } else if (firstDigit === '5') {
        if (secondDigit === '2' || secondDigit === '3' || secondDigit === '4' || secondDigit === '5') {
            document.getElementById("mastercardImage").style.display = "inline";
        }        
    }
}

