public record Coupan(int Id, string Name, DateTime CreatedDate, Boolean IsActive, DateTime ValidUpto)
{
    public static void SetIsCoupanActive(DateTime CreatedDate, DateTime ValidUpto, bool isActive)
    {
        if (ValidUpto > DateTime.Now)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }
}
