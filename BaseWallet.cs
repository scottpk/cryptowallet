using QRCoder;

namespace cryptowallet {
    public abstract class BaseWallet : IWallet
    {
        public byte[] IdHash => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();

        public string Address => throw new System.NotImplementedException();

        public QRCode QRCode => throw new System.NotImplementedException();
    }
}