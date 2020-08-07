function validateForm() {
    var name = document.forms["user-form"]["Name"].value;
    var address = document.forms["user-form"]["Address"].value;
    var town = document.forms["user-form"]["Town"].value;
    var country = document.forms["user-form"]["Country"].value;
    var mail = document.forms["user-form"]["Mail"].value;
    var doB = document.forms["user-form"]["DoB"].value;
    var isActive = document.forms["user-form"]["IsActive"].value;
    var username = document.forms["user-form"]["Username"].value;
    var password = document.forms["user-form"]["Password"].value;
    var rating = document.forms["user-form"]["Rating"].value;
    if (name == "" || address == "" || town == "" || country == "" || mail == "" || doB == "" || isActive == "" || username == "" || password == "" || rating == "") {
        alert("Error: Enter all fields!");
        return false;
    }
}