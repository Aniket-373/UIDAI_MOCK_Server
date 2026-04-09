
public static class AadhaarMockData
{
    public static Dictionary<string, AadhaarUser> Users = new()
    {
        ["999941057058"] = new AadhaarUser
        {
            Name = "Shivshankar Choudhury",
            Dob = "13-05-1968",
            Gender = "M",
            Phone = "9877896979",
            Email = "sschoudhury@dummyemail.com",
            District = "New Delhi",
            State = "Delhi",
            Pincode = "110002"
        },
        ["999955183433"] = new AadhaarUser
        {
            Name = "Rohit Pandey",
            Dob = "08-07-1985",
            Gender = "M",
            Phone = "9877896979",
            District = "Mumbai",
            State = "Maharashtra",
            Pincode = "400001"
        },
        ["999971658847"] = new AadhaarUser
        {
            Name="Kumar Agarwal",
            Dob="04-05-1978",
            Gender="M",
            Phone="2314475929",
            Email="kma@mailserver.com",
            District="Udaipur",
            State="Rajasthan",
            Pincode="313001"
        },
        ["999933119405"]  = new AadhaarUser
        {
            Name="Fatima Bedi",
            Dob="30-07-1943",
            Gender="F",
            Phone="2837032088",
            Email="bedi2020@mailserver.com",
            District="Bareilly",
            State="Uttar Pradesh",
            Pincode="243001"
        },
        ["999990501894"] = new AadhaarUser
        {
            Name="Anisha Jay Kapoor",
            Gender="F",
            Dob="01-01-1982",
            District="Bangalore",
            State="Karnataka",
            Pincode="560036"
        },
        ["723320200072"] = new AadhaarUser
        {
            Name="Chandramohan Thakur",
            Gender="M",
            Dob="01-01-2001",
            District="Palghar",
            State="Maharashtra",
            Pincode="401506"
        }
    };
}