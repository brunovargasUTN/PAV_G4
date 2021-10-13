using Microsoft.ReportingServices.ReportIntermediateFormat.Persistence;
using Microsoft.ReportingServices.ReportProcessing;
using System;
using System.Collections.Generic;

namespace Microsoft.ReportingServices.ReportIntermediateFormat
{
	[Serializable]
	internal sealed class BandLayoutOptions : IPersistable
	{
		[NonSerialized]
		private static readonly Declaration m_Declaration = GetDeclaration();

		private int m_rowCount = 1;

		private int m_columnCount = 1;

		private Navigation m_navigation;

		internal int RowCount
		{
			get
			{
				return m_rowCount;
			}
			set
			{
				m_rowCount = value;
			}
		}

		internal int ColumnCount
		{
			get
			{
				return m_columnCount;
			}
			set
			{
				m_columnCount = value;
			}
		}

		internal Navigation Navigation
		{
			get
			{
				return m_navigation;
			}
			set
			{
				m_navigation = value;
			}
		}

		internal void Initialize(Tablix tablix, InitializationContext context)
		{
			if (m_navigation != null)
			{
				m_navigation.Initialize(tablix, context);
			}
		}

		internal static Declaration GetDeclaration()
		{
			List<MemberInfo> list = new List<MemberInfo>();
			list.Add(new MemberInfo(MemberName.RowCount, Token.Int32));
			list.Add(new MemberInfo(MemberName.ColumnCount, Token.Int32));
			list.Add(new MemberInfo(MemberName.Navigation, Microsoft.ReportingServices.ReportIntermediateFormat.Persistence.ObjectType.Navigation));
			return new Declaration(Microsoft.ReportingServices.ReportIntermediateFormat.Persistence.ObjectType.BandLayoutOptions, Microsoft.ReportingServices.ReportIntermediateFormat.Persistence.ObjectType.None, list);
		}

		public void Serialize(IntermediateFormatWriter writer)
		{
			writer.RegisterDeclaration(m_Declaration);
			while (writer.NextMember())
			{
				switch (writer.CurrentMember.MemberName)
				{
				case MemberName.RowCount:
					writer.Write(m_rowCount);
					break;
				case MemberName.ColumnCount:
					writer.Write(m_columnCount);
					break;
				case MemberName.Navigation:
					writer.Write(m_navigation);
					break;
				default:
					Global.Tracer.Assert(condition: false);
					break;
				}
			}
		}

		public void Deserialize(IntermediateFormatReader reader)
		{
			reader.RegisterDeclaration(m_Declaration);
			while (reader.NextMember())
			{
				switch (reader.CurrentMember.MemberName)
				{
				case MemberName.RowCount:
					m_rowCount = reader.ReadInt32();
					break;
				case MemberName.ColumnCount:
					m_columnCount = reader.ReadInt32();
					break;
				case MemberName.Navigation:
					m_navigation = (Navigation)reader.ReadRIFObject();
					break;
				default:
					Global.Tracer.Assert(condition: false);
					break;
				}
			}
		}

		public void ResolveReferences(Dictionary<Microsoft.ReportingServices.ReportIntermediateFormat.Persistence.ObjectType, List<MemberReference>> memberReferencesCollection, Dictionary<int, IReferenceable> referenceableItems)
		{
		}

		public Microsoft.ReportingServices.ReportIntermediateFormat.Persistence.ObjectType GetObjectType()
		{
			return Microsoft.ReportingServices.ReportIntermediateFormat.Persistence.ObjectType.BandLayoutOptions;
		}
	}
}
