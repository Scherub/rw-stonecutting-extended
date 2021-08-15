using System.Linq;
using System.Xml;
using Verse;

namespace StonecuttingExtended
{
	/// <summary>
	/// Patch Operation to either Add or Replace a node.
	/// Unfortunately, the patcher doesn't seem to recognise this class, so it doesn't work for now.
	/// </summary>
	public class PatchOperationAddOrReplace : PatchOperationPathed
	{
		private XmlContainer value;

		protected override bool ApplyWorker(XmlDocument xml)
		{
			XmlNode valueNode = value.node;

			bool result = false;

			foreach (XmlNode xmlNode in xml.SelectNodes(xpath).Cast<XmlNode>().ToArray())
			{
				result = true;

				foreach (var valueChildNode in valueNode.ChildNodes.Cast<XmlNode>())
				{
					XmlNode xmlChildNode = xmlNode.SelectSingleNode(valueNode.Name);

					if (xmlChildNode == null)
					{
						xmlNode.AppendChild(xmlNode.OwnerDocument.ImportNode(valueChildNode, true));
					}
					else
					{
						xmlNode.InsertBefore(xmlNode.OwnerDocument.ImportNode(valueChildNode, true), xmlChildNode);
						xmlNode.RemoveChild(xmlChildNode);
					}
				}
			}

			return result;
		}
	}
}
