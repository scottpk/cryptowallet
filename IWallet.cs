namespace cryptowallet {
    public interface IWallet{
        public string Address {get;set;}
        public QRCoder.QRCode QRCode{ get; }
    }
}