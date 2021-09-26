namespace cryptowallet {
    public interface IWallet{
        byte[] IdHash {get;}
        string Name {get;}
        string Address {get;}
        string Icon {get;}
        decimal Balance{get;}
        QRCoder.QRCode QRCode{ get; }
        string Send(string address, decimal amount, System.Threading.CancellationToken token);
    }
}