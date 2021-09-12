namespace cryptowallet {
    public interface IWallet{
        byte[] IdHash {get;}
        string Name {get;}
        string Address {get;}
        QRCoder.QRCode QRCode{ get; }
    }
}