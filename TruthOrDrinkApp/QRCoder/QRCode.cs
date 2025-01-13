

namespace QRCoder
{
	internal class QRCode
	{
		private QRCodeData qrCodeData;

		public QRCode(QRCodeData qrCodeData)
		{
			this.qrCodeData = qrCodeData;
		}

		internal IDisposable GetGraphic(int v)
		{
			throw new NotImplementedException();
		}
	}
}