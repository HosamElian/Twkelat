namespace Twkelat.Persistence.BlockExtension
{
    public interface IBlock
    {
        //byte[] DataHash { get; }
        byte[] Hash { get; set; }
        byte[] PrevHash { get; set; }
        int Nonce { get; set; }
        DateTime TimeStamp { get; set; }
        string CreateForId { get; set; }
        string CreateById { get; set; }
        int? TempleteId { get; set; }
        int PowerAttorneyTypeId { get; set; }
        string Scope { get; set; }
    }
}
