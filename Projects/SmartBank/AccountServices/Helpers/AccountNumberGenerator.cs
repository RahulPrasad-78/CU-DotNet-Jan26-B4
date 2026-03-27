namespace AccountServices.Helpers
{
    public class AccountNumberGenerator
    {
        public static string GenerateAccountNumber(int year, int id)
        {
            string accountNumb = string.Empty;
            string aID = id.ToString().PadLeft(6, '0');
            accountNumb += $"SB-{year}-{aID}";
            return accountNumb;
        }
    }
}
