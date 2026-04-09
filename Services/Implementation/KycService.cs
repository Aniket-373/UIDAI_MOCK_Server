// Services/Implementation/KycService.cs
using System.Xml.Linq;
using System.Text;

public class KycService : IKycService
{
    public string Process(string xml, string? scenario)
    {
        var uid = ExtractUid(xml);

        if (scenario == "INVALID_UID")
            return BuildError("998", "Invalid Aadhaar");

        if (string.IsNullOrEmpty(uid))
            return BuildError("510", "Invalid XML");

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
        var kycXml = $"""
<KycRes ret="Y" code="100" txn="UKC:{Guid.NewGuid()}"
        ts="{DateTime.UtcNow:o}" ttl="{DateTime.UtcNow.AddHours(1):o}">
    <UidData uid="{uid}">
        <Poi name="{user.Name}" dob="{user.Dob}" gender="{user.Gender}"
             phone="{user.Phone}" email="{user.Email}" />
        <Poa dist="{user.District}" state="{user.State}" pc="{user.Pincode}" />
        <LData lang="en" name="{user.Name}" />
        <Pht></Pht>
    </UidData>
</KycRes>
""";

        // var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(kycXml));

        return $"""
<Resp status="0">
    <kycRes>{kycXml}</kycRes>
</Resp>
""";
    }

    private string BuildError(string code, string message)
    {
        var xml = $"""<KycRes ret="N" code="{code}" err="{message}" />""";

        // var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));

        return $"""
<Resp status="-1">
    <kycRes>{xml}</kycRes>
</Resp>
""";
    }
}