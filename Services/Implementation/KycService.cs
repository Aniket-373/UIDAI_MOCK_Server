using System.Xml.Linq;
using System.Text;

public class KycService : IKycService
{
    private static readonly Random _random = new();

    private (string uid, AadhaarUser user) GetRandomUser()
    {
        var users = AadhaarMockData.Users.ToList();
        var index = _random.Next(users.Count);
        var selected = users[index];

        return (selected.Key, selected.Value);
    }

    public string Process(string xml, string? scenario)
    {
        var uid = ExtractUid(xml);

        // Force invalid scenario
        if (scenario == "INVALID_UID")
            return BuildError("998", "Invalid Aadhaar");

        // Always random if explicitly asked
        if (scenario == "RANDOM")
        {
            var (randomUid, randomUser) = GetRandomUser();
            return BuildSuccess(randomUser, randomUid);
        }

        // If UID NOT passed → return random instead of error
        if (string.IsNullOrEmpty(uid))
        {
            var (randomUid, randomUser) = GetRandomUser();
            return BuildSuccess(randomUser, randomUid);
        }

        
        if (!AadhaarMockData.Users.ContainsKey(uid))
            return BuildError("998", "Invalid Aadhaar");

        var user = AadhaarMockData.Users[uid];

        return BuildSuccess(user, uid);
    }

    private string ExtractUid(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            return doc.Root?.Attribute("uid")?.Value ?? "";
        }
        catch
        {
            return "";
        }
    }

    private string BuildSuccess(AadhaarUser user, string uid)
{
    var fakePdfContent = $"Aadhaar PDF for {user.Name}";
    var pdfBytes = System.Text.Encoding.UTF8.GetBytes(fakePdfContent);
    var pdfBase64 = Convert.ToBase64String(pdfBytes);

    var kycXml = $"""
<KycRes ret="Y" code="100" txn="UKC:{Guid.NewGuid()}"
        ts="{DateTime.UtcNow:o}" ttl="{DateTime.UtcNow.AddHours(1):o}">
    <UidData uid="{uid}">
        <Poi name="{user.Name}" dob="{user.Dob}" gender="{user.Gender}"
             phone="{user.Phone}" email="{user.Email}" />
        <Poa dist="{user.District}" state="{user.State}" pc="{user.Pincode}" />
        <LData lang="en" name="{user.Name}" />

        <Pht>{Convert.ToBase64String(Guid.NewGuid().ToByteArray())}</Pht>
    </UidData>

    <EadhaarPdf>{pdfBase64}</EadhaarPdf>

</KycRes>
""";

    return $"""
<Resp status="0">
    <kycRes>{kycXml}</kycRes>
</Resp>
""";
}

    private string BuildError(string code, string message)
    {
        var xml = $"""<KycRes ret="N" code="{code}" err="{message}" />""";

        return $"""
<Resp status="-1">
    <kycRes>{xml}</kycRes>
</Resp>
""";
    }
}