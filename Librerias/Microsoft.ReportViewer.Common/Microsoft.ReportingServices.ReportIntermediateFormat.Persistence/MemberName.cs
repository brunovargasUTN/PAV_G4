namespace Microsoft.ReportingServices.ReportIntermediateFormat.Persistence
{
	internal enum MemberName
	{
		FieldValueSerializable = 10000,
		ID = 0,
		ReaderExtensionsSupported = 1,
		FieldPropertyNames = 2,
		CompareOptions = 3,
		RecordFields = 4,
		IsAggregateRow = 5,
		AggregationFieldCount = 6,
		PropertyNames = 7,
		FieldStatus = 8,
		FieldValue = 9,
		IsAggregateField = 10,
		FieldPropertyValues = 11,
		CellAggregates = 12,
		CellPostSortAggregates = 13,
		CellRunningValues = 14,
		DataSetIndexInCollection = 0xF,
		RowMembers = 0x10,
		ColumnMembers = 17,
		Cells = 18,
		MemberInstanceIndexWithinScopeLevel = 19,
		Children = 20,
		Variable = 21,
		Variables = 22,
		RecursiveLevel = 23,
		GroupExpressionValues = 24,
		RecordSetSize = 25,
		RewrittenCommandText = 26,
		Fields = 27,
		CaseSensitivity = 28,
		Collation = 29,
		AccentSensitivity = 30,
		KanatypeSensitivity = 0x1F,
		WidthSensitivity = 0x20,
		LCID = 33,
		TablixProcessingComplete = 34,
		FieldPropertyReaderIndices = 35,
		NoRows = 36,
		Language = 37,
		DataSetInstances = 38,
		FirstRowIndex = 39,
		DataRegionInstances = 40,
		SubReportInstances = 41,
		AggregateValues = 42,
		SubReport = 43,
		ReportInstance = 44,
		DataSetUniqueName = 45,
		ThreadCulture = 46,
		Parameters = 47,
		Status = 48,
		ProcessedWithError = 49,
		LastID = 50,
		UniqueName = 51,
		ReportPath = 52,
		ParametersFromCatalog = 53,
		Name = 54,
		Value = 55,
		DataType = 56,
		AggregateType = 57,
		Expressions = 58,
		DuplicateNames = 59,
		Scope = 60,
		TotalGroupingExpressionCount = 61,
		IsScopedInEvaluationScope = 62,
		IsInOutermostStatic = 0x3F,
		ParentInstanceIndex = 0x40,
		IsInstanceShared = 65,
		DataChunkNameModifier = 66,
		OdpContext = 67,
		ProcessedPreviousAggregates = 68,
		ReportObjectModel = 69,
		AggregationFieldChecked = 70,
		Properties = 71,
		FieldDef = 72,
		UsedInExpression = 73,
		HierarchyRoot = 74,
		SortHierarchyStruct = 75,
		DataHolder = 76,
		Owner = 77,
		ScopeInstances = 78,
		ScopeValuesList = 79,
		SortTree = 80,
		CurrentScopeIndex = 81,
		ScopeInstanceIndices = 82,
		Tuples = 83,
		IndexInParent = 84,
		List = 85,
		Capacity = 86,
		Child = 87,
		Key = 88,
		HierarchyNode = 89,
		OuterGroupDynamicIndex = 90,
		RowIndexes = 91,
		ColumnIndexes = 92,
		CellNonCustomAggObjs = 93,
		CellCustomAggObjs = 94,
		CellAggValueList = 95,
		RunningValueValues = 96,
		Innermost = 97,
		FirstRow = 98,
		FirstRowIsAggregate = 99,
		NextCell = 100,
		SortFilterExpressionScopeInfoIndices = 101,
		CellsWithSameScope = 102,
		ReportItemColIndex = 103,
		OuterScope = 104,
		NonCustomAggregates = 105,
		CustomAggregates = 106,
		DataAction = 107,
		OuterDataAction = 108,
		InnerDataAction = 109,
		UserSortTargetInfo = 110,
		NonAggregateMode = 111,
		Aggregator = 112,
		AggregateDef = 113,
		ReportRuntime = 114,
		AggregateResult = 115,
		Updated = 116,
		ExpressionType = 117,
		CurrentTotalType = 118,
		CurrentTotal = 119,
		CurrentCount = 120,
		CompareInfo = 121,
		CurrentMax = 122,
		DistinctValues = 123,
		SumOfXType = 124,
		SumOfX = 125,
		SumOfXSquared = 126,
		Previous = 0x7F,
		StyleClass = 0x80,
		Top = 129,
		TopValue = 130,
		Left = 131,
		LeftValue = 132,
		Height = 133,
		HeightValue = 134,
		Width = 135,
		WidthValue = 136,
		ZIndex = 137,
		Visibility = 138,
		Label = 139,
		RepeatedSibling = 140,
		Author = 141,
		AutoRefresh = 142,
		EmbeddedImages = 143,
		PageHeader = 144,
		PageFooter = 145,
		ReportItems = 146,
		DataSources = 147,
		PageHeight = 148,
		PageHeightValue = 149,
		PageWidth = 150,
		PageWidthValue = 151,
		LeftMargin = 152,
		LeftMarginValue = 153,
		RightMargin = 154,
		RightMarginValue = 155,
		TopMargin = 156,
		TopMarginValue = 157,
		BottomMargin = 158,
		BottomMarginValue = 159,
		ClassName = 160,
		InstanceName = 161,
		CodeModules = 162,
		CodeClasses = 163,
		Columns = 164,
		ColumnSpacing = 165,
		ColumnSpacingValue = 166,
		PageAggregates = 167,
		CompiledCode = 168,
		MergeOnePass = 169,
		PageMergeOnePass = 170,
		SubReportMergeTransactions = 171,
		NeedPostGroupProcessing = 172,
		HasPostSortAggregates = 173,
		HasReportItemReferences = 174,
		ShowHideType = 175,
		BodyID = 176,
		PrintOnFirstPage = 177,
		PrintOnLastPage = 178,
		PostProcessEvaluate = 179,
		Slanted = 180,
		PageBreakAtEnd = 181,
		PageBreakAtStart = 182,
		HyperLinkURL = 183,
		Source = 184,
		MIMEType = 185,
		Sizing = 186,
		HideDuplicates = 187,
		CanGrow = 188,
		CanShrink = 189,
		IsToggle = 190,
		InitialToggleState = 191,
		MergeTransactions = 192,
		ReportName = 193,
		Description = 194,
		Report = 195,
		StringUri = 196,
		ClassID = 197,
		CodeBase = 198,
		DataSetName = 199,
		KeepTogether = 200,
		RepeatSiblings = 201,
		Grouping = 202,
		Sorting = 203,
		DataRegionDef = 204,
		GroupExpressions = 205,
		GroupLabel = 206,
		SortDirections = 207,
		Aggregates = 208,
		GroupAndSort = 209,
		SortExpressions = 210,
		ColumnCount = 211,
		RowCount = 212,
		InnerRowLevelWithPageBreak = 213,
		GroupsBeforeRowHeaders = 214,
		ProcessingInnerGrouping = 215,
		Size = 216,
		SizeValue = 217,
		Subtotal = 218,
		Level = 219,
		IsColumn = 220,
		Position = 221,
		RunningValues = 222,
		ChartSeriesCollection = 223,
		ChartAreas = 224,
		Titles = 225,
		AxisTitle = 226,
		LegendTitle = 227,
		BorderSkin = 228,
		Title = 229,
		TitleAngle = 230,
		StripWidth = 231,
		StripWidthType = 232,
		CellType = 233,
		Text = 234,
		CellSpan = 235,
		ImageWidth = 236,
		ImageHeight = 237,
		SymbolHeight = 238,
		SymbolWidth = 239,
		Alignment = 240,
		ColumnType = 241,
		ToolTip = 242,
		MinimumWidth = 243,
		MaximumWidth = 244,
		SeriesSymbolWidth = 245,
		SeriesSymbolHeight = 246,
		Header = 247,
		Marker = 248,
		Separator = 249,
		SeparatorColor = 250,
		AllowOutSidePlotArea = 251,
		CalloutBackColor = 252,
		CalloutLineAnchor = 253,
		CalloutLineColor = 254,
		CalloutLineStyle = 0xFF,
		CalloutLineWidth = 0x100,
		CalloutStyle = 257,
		HideOverlapped = 258,
		MarkerOverlapping = 259,
		MaxMovingDistance = 260,
		MinMovingDistance = 261,
		NoMoveDirections = 262,
		Up = 263,
		Down = 264,
		Right = 265,
		UpLeft = 266,
		UpRight = 267,
		DownLeft = 268,
		DownRight = 269,
		Visible = 270,
		Margin = 271,
		Interval = 272,
		IntervalType = 273,
		IntervalOffset = 274,
		IntervalOffsetType = 275,
		MajorTickMarks = 276,
		MinorTickMarks = 277,
		MarksNextToAxis = 278,
		Reverse = 279,
		Location = 280,
		Interlaced = 281,
		InterlacedColor = 282,
		LogScale = 283,
		LogBase = 284,
		Angle = 285,
		Arrows = 286,
		AllowLabelRotation = 287,
		IncludeZero = 288,
		MinFontSize = 289,
		MaxFontSize = 290,
		OffsetLabels = 291,
		AxisScaleBreak = 292,
		Series = 293,
		SourceChartSeriesName = 294,
		DerivedSeriesFormula = 295,
		DataLabel = 296,
		AxisLabel = 297,
		ChartItemInLegend = 298,
		LegendText = 299,
		Length = 300,
		CustomPaletteColors = 301,
		CustomPaletteColor = 302,
		Color = 303,
		CodeParameters = 304,
		NoDataMessage = 305,
		LegendColumn = 306,
		LegendColumnHeader = 307,
		LegendCustomItems = 308,
		LegendCustomCells = 309,
		ChartStripLines = 310,
		ChartLegendColumns = 311,
		ChartLegendCustomItems = 312,
		ChartLegendCustomItemCells = 313,
		ChartDerivedSeriesCollection = 314,
		ChartFormulaParameters = 315,
		FormulaParamters = 316,
		EmptyPoints = 317,
		SmartLabel = 318,
		NoMoveDirection = 319,
		ChartLegends = 320,
		NonComputedReportItems = 321,
		ComputedReportItems = 322,
		SortedReportItems = 323,
		IsComputed = 324,
		Index = 325,
		StyleAttributes = 326,
		ExpressionList = 327,
		IsExpression = 328,
		StringValue = 329,
		BoolValue = 330,
		IntValue = 331,
		Hidden = 332,
		Toggle = 333,
		Type = 334,
		Transaction = 335,
		ConnectString = 336,
		DataSets = 337,
		DataField = 338,
		Query = 339,
		DataRegions = 340,
		CommandType = 341,
		CommandText = 342,
		QueryParameters = 343,
		Timeout = 344,
		StartHidden = 345,
		ReceiverUniqueNames = 346,
		ContainerUniqueNames = 347,
		SenderUniqueName = 348,
		Offset = 349,
		OffsetInfo = 350,
		ReportItemColInstance = 351,
		StyleAttributeValues = 352,
		RequestUserName = 353,
		BodyUniqueName = 354,
		ChildrenUniqueNames = 355,
		ReportItemInstances = 356,
		ChildrenNonComputedUniqueNames = 357,
		OriginalValue = 358,
		DocumentMap = 359,
		Nullable = 360,
		Prompt = 361,
		PromptUser = 362,
		IsUserSupplied = 363,
		QuickFind = 364,
		Images = 365,
		Bookmark = 366,
		IntegratedSecurity = 367,
		DataSourceReference = 368,
		LinkToChild = 369,
		DrillthroughReportName = 370,
		DrillthroughParameters = 371,
		BookmarkLink = 372,
		LayoutDirection = 373,
		Expression = 374,
		Operator = 375,
		Values = 376,
		Filters = 377,
		SubReports = 378,
		HasImageStreams = 379,
		IsFullSize = 380,
		HasBookmarks = 381,
		HasLabels = 382,
		ParametersNotUsedInQuery = 383,
		DrillthroughBookmarkLink = 384,
		UsedInQuery = 385,
		UsedOnlyInParameters = 386,
		AllowBlank = 387,
		MultiValue = 388,
		ValidValues = 389,
		DefaultValue = 390,
		ValidValuesDataSource = 391,
		ValidValuesValueExpression = 392,
		ValidValuesLabelExpression = 393,
		DefaultValueDataSource = 394,
		DataSourceIndex = 395,
		DataSetIndex = 396,
		ValueFieldIndex = 397,
		LabelFieldIndex = 398,
		DynamicValidValues = 399,
		DynamicDefaultValue = 400,
		DependencyList = 401,
		NonCalculatedFieldCount = 402,
		ExecutionTime = 403,
		ReportServerUrl = 404,
		ReportFolder = 405,
		Formula = 406,
		ProcessingMessages = 407,
		Code = 408,
		Severity = 409,
		ObjectType = 410,
		ObjectName = 411,
		PropertyName = 412,
		Message = 413,
		CommonCode = 414,
		ReportItemsWithHideDuplicates = 415,
		ExprHostID = 416,
		HasExprHost = 417,
		ValueReferenced = 418,
		Omit = 419,
		Parent = 420,
		PostSortAggregates = 421,
		RecursiveAggregates = 422,
		HasSpecialRecursiveAggregates = 423,
		RecursiveSender = 424,
		RecursiveReceiver = 425,
		Action = 426,
		SubType = 427,
		PointWidth = 428,
		ThreeDProperties = 429,
		DataTransform = 430,
		DataSchema = 431,
		DataElementName = 432,
		DataElementStyleAttribute = 433,
		DataElementOutput = 434,
		DataCollectionName = 435,
		Palette = 436,
		Caption = 437,
		PlotArea = 438,
		Layout = 439,
		MajorGridLines = 440,
		MinorGridLines = 441,
		MajorInterval = 442,
		MinorInterval = 443,
		ShowGridLines = 444,
		Minimum = 445,
		Maximum = 446,
		AutoScaleMin = 447,
		AutoScaleMax = 448,
		CrossAt = 449,
		AutoCrossAt = 450,
		DataValues = 451,
		DataPointValues = 452,
		X = 453,
		Y = 454,
		High = 455,
		Low = 456,
		Start = 457,
		End = 458,
		Mean = 459,
		Median = 460,
		MarkerStyleClass = 461,
		PerspectiveProjectionMode = 462,
		Rotation = 463,
		Inclination = 464,
		Perspective = 465,
		HeightRatio = 466,
		DepthRatio = 467,
		Shading = 468,
		GapDepth = 469,
		WallThickness = 470,
		Origin = 471,
		InsidePlotArea = 472,
		Enabled = 473,
		DrawingStyleCube = 474,
		Clustered = 475,
		Scalar = 476,
		PlotTypesLine = 477,
		CultureName = 478,
		StartPage = 479,
		EndPage = 480,
		NumberOfPages = 481,
		Page = 482,
		IntermediateFormatVersionMajor = 483,
		IntermediateFormatVersionMinor = 484,
		IntermediateFormatVersionBuild = 485,
		ReportVersion = 486,
		StreamName = 487,
		ActionItem = 488,
		ActionItemList = 489,
		CustomProperties = 490,
		HasDocumentMap = 491,
		HasShowHide = 492,
		DocMapPage = 493,
		RenderReportItemColDef = 494,
		EventSource = 495,
		EventSourceScopeInfo = 496,
		DataSetID = 497,
		ContainingScopes = 498,
		UserSort = 499,
		SortExpressionScope = 500,
		GroupsInSortTarget = 501,
		SortTarget = 502,
		HasDetailUserSortFilter = 503,
		SaveGroupExprValues = 504,
		HasUserSortFilter = 505,
		IsTablixCellScope = 506,
		UserSortExpressions = 507,
		SortExpressionIndex = 508,
		CommandTextValue = 509,
		SharedDataSourceReferencePath = 510,
		DynamicFieldReferences = 0x1FF,
		DynamicPropertyReferences = 0x200,
		ReferencedProperties = 513,
		CompiledCodeGeneratedWithRefusedPermissions = 514,
		InteractiveHeight = 515,
		InteractiveHeightValue = 516,
		InteractiveWidth = 517,
		InteractiveWidthValue = 518,
		PageNumber = 519,
		DetailScopeSubReports = 520,
		DataSetUniqueNameMap = 521,
		LookupTable = 522,
		LookupInt = 523,
		IsSubReportTopLevelScope = 524,
		NonDetailSortFiltersInScope = 525,
		DetailSortFiltersInScope = 526,
		DrillthroughHashtable = 527,
		RewrittenCommands = 528,
		PageBreakLocation = 529,
		PropagatedPageBreakLocation = 530,
		Tablix = 531,
		TablixHeader = 532,
		TablixRow = 533,
		TablixRows = 534,
		TablixCell = 535,
		TablixCells = 536,
		CellContents = 537,
		TablixColumn = 538,
		TablixColumns = 539,
		TablixMember = 540,
		TablixMembers = 541,
		TablixColumnMembers = 542,
		TablixRowMembers = 543,
		TablixCornerCells = 544,
		RepeatColumnHeaders = 545,
		RepeatRowHeaders = 546,
		FixedColumnHeaders = 547,
		FixedRowHeaders = 548,
		KeepWithGroup = 549,
		FixedData = 550,
		NoRowsMessage = 551,
		ColSpan = 552,
		RowSpan = 553,
		AutoSubtotal = 554,
		MemberCellIndex = 555,
		CategoryMembers = 556,
		SeriesMembers = 557,
		ChartSeries = 558,
		ChartDataPoints = 559,
		Subtype = 560,
		LegendName = 561,
		ChartAreaName = 562,
		ValueAxisName = 563,
		CategoryAxisName = 564,
		PlotAsLine = 565,
		DataColumnMembers = 566,
		DataRowMembers = 567,
		DataMembers = 568,
		DataRows = 569,
		AltReportItem = 570,
		OmitBorderOnPageBreak = 571,
		DynamicHeight = 572,
		DynamicWidth = 573,
		ReGroupExpressions = 574,
		DeferVariableEvaluation = 575,
		ExpressionInfoTypeValuePair = 576,
		HideIfNoRows = 577,
		InterpretSubtotalsAsDetails = 578,
		ValueAxes = 579,
		CategoryAxes = 580,
		ChartMembers = 581,
		AngleValue = 582,
		PlotType = 583,
		ParentRowID = 584,
		ParentColumnID = 585,
		DynamicPrompt = 586,
		HasSubReports = 587,
		HideStaticsIfNoRows = 588,
		InScopeTextBoxes = 589,
		ColumnHeaderRowCount = 590,
		RowHeaderColumnCount = 591,
		IndexInCollection = 592,
		ReportSnapshot = 593,
		FirstDataSet = 594,
		DataSetNoRows = 595,
		DataSetRecordSetSizes = 596,
		ErrorOccurred = 597,
		HasCode = 598,
		GroupTreePartitionOffsets = 599,
		TopLevelScopeInstances = 600,
		ToggleSender = 601,
		Names = 602,
		Count = 603,
		IsMultiValue = 604,
		LockAdd = 605,
		SubReportInfos = 606,
		Computed = 607,
		RepeatOnNewPage = 608,
		TopLeftDataRegion = 609,
		HasInnerGroupTreeHierarchy = 610,
		ImageChunkNames = 611,
		DataSetsNotOnlyUsedInParameters = 612,
		ChartStyleContainer = 613,
		Chart = 614,
		ChartDataPoint = 615,
		AggregateIndexes = 616,
		PostSortAggregateIndexes = 617,
		RunningValueIndexes = 618,
		AltCellContents = 619,
		ROMIndexMap = 620,
		AltReportItemIndexInParentCollectionDef = 621,
		InPrevious = 622,
		NeedToCacheDataRows = 623,
		HasPreviousAggregates = 624,
		BreakLineType = 625,
		CollapsibleSpaceThreshold = 626,
		MaxNumberOfBreaks = 627,
		Spacing = 628,
		BorderSkinType = 629,
		TopLevelDataRegionIndexes = 630,
		InScopeEventSources = 631,
		InScopeTextBoxesInPage = 632,
		InScopeTextBoxesInBody = 633,
		CachedExternalImages = 634,
		TransparentImageChunkName = 635,
		DataChunkName = 636,
		DataChunkMap = 637,
		EventSources = 638,
		DataSet = 639,
		ChunkNameModifier = 640,
		ReferenceID = 641,
		DataSource = 642,
		RetrievalFailed = 643,
		ContainingDynamicVisibility = 644,
		ContainingDynamicRowVisibility = 645,
		ContainingDynamicColumnVisibility = 646,
		ImageData = 647,
		Actions = 648,
		ActionDefinition = 649,
		ImageMapAreas = 650,
		Shape = 651,
		Coordinates = 652,
		Style = 653,
		CustomPropertyNames = 654,
		CustomPropertyValues = 655,
		GeneratedReportItemChunkNames = 656,
		ChartSmartLabel = 657,
		InDynamicRowAndColumnContext = 658,
		SortFilterEventInfos = 659,
		OuterGroupingMaximumDynamicLevel = 660,
		OuterGroupingDynamicMemberCount = 661,
		OuterGroupingDynamicPathCount = 662,
		HierarchyDynamicIndex = 663,
		HierarchyPathIndex = 664,
		AggregateFieldReferences = 665,
		TrackFieldsUsedInValueExpression = 666,
		Docking = 667,
		DockToChartArea = 668,
		DockOutsideChartArea = 669,
		DockOffset = 670,
		TitleSeparator = 671,
		AlignOrientation = 672,
		ChartAlignType = 673,
		AlignWithChartArea = 674,
		EquallySizedAxesFont = 675,
		Cursor = 676,
		AxesView = 677,
		InnerPlotPosition = 678,
		ChartLegendTitle = 679,
		AutoFitTextDisabled = 680,
		HeaderSeparator = 681,
		HeaderSeparatorColor = 682,
		ColumnSeparator = 683,
		ColumnSeparatorColor = 684,
		InterlacedRows = 685,
		InterlacedRowsColor = 686,
		EquallySpacedItems = 687,
		Reversed = 688,
		MaxAutoSize = 689,
		TextWrapThreshold = 690,
		ShowOverlapped = 691,
		HideInLegend = 692,
		UseValueAsLabel = 693,
		ProjectionMode = 694,
		MarksAlwaysAtPlotEdge = 695,
		HideLabels = 696,
		PreventFontShrink = 697,
		PreventFontGrow = 698,
		PreventLabelOffset = 699,
		PreventWordWrap = 700,
		LabelsAutoFitDisabled = 701,
		HideEndLabels = 702,
		VariableAutoInterval = 703,
		LabelInterval = 704,
		LabelIntervalType = 705,
		LabelIntervalOffset = 706,
		LabelIntervalOffsetType = 707,
		IsMajor = 708,
		GroupsWithVariables = 709,
		InstanceParameterValues = 710,
		HierarchyParentGroups = 711,
		InnerGroupingMaximumDynamicLevel = 712,
		InnerGroupingDynamicMemberCount = 713,
		InnerGroupingDynamicPathCount = 714,
		GroupTreeRootOffset = 715,
		Item = 716,
		Priority = 717,
		AggregateRows = 718,
		SortFilterInfoIndices = 719,
		TargetForNonDetailSort = 720,
		TargetForDetailSort = 721,
		FirstCell = 722,
		LastCell = 723,
		CurrentMin = 724,
		ReportItemsDef = 725,
		CellReportItemDef = 726,
		CellAltReportItemDef = 727,
		ReportItemDef = 728,
		DataRegionObjs = 729,
		CurrentDataRegion = 730,
		ProcessSubreports = 731,
		OldUniqueName = 732,
		SortSourceScopeInfo = 733,
		SortDirection = 734,
		EventSourceRowScope = 735,
		EventSourceColDetailIndex = 736,
		EventSourceRowDetailIndex = 737,
		DetailRowScopes = 738,
		DetailRowScopeIndices = 739,
		DetailColScopeIndices = 740,
		EventTarget = 741,
		TargetSortFilterInfoAdded = 742,
		GroupExpressionsInSortTarget = 743,
		SortFilterExpressionScopeObjects = 744,
		CurrentSortIndex = 745,
		CurrentInstanceIndex = 746,
		SortOrders = 747,
		Processed = 748,
		NullScopeCount = 749,
		NewUniqueName = 750,
		PeerSortFilters = 751,
		Direction = 752,
		ExpressionsHost = 753,
		ExpressionIndex = 754,
		HierarchyObjs = 755,
		Hashtable = 756,
		Tree = 757,
		ParentInfo = 758,
		FirstChild = 759,
		LastChild = 760,
		RvValueList = 761,
		RunningValuesInGroup = 762,
		PreviousValuesInGroup = 763,
		GlobalRunningValueCollection = 764,
		GroupCollection = 765,
		ProcessingStage = 766,
		ScopedRunningValues = 767,
		ParentInstance = 768,
		GroupingType = 769,
		ParentExpression = 770,
		CurrentGroupExprValue = 771,
		BuiltinSortOverridden = 772,
		IsDetailGroup = 773,
		HierarchyDef = 774,
		Collection = 775,
		ErrorContext = 776,
		InnerGroupings = 777,
		OutermostStaticCellRvs = 778,
		HeadingLevel = 779,
		OutermostStatics = 780,
		HasLeafCells = 781,
		ProcessOutermostStaticCells = 782,
		CurrentMemberIndexWithinScopeLevel = 783,
		CurrentMemberInstance = 784,
		GroupRoot = 785,
		HasStaticMembers = 786,
		StaticLeafCellIndexes = 787,
		StaticHeadings = 788,
		OuterGroupingCounters = 789,
		OuterGroupings = 790,
		InnerGroupsWithCellsForOuterPeerGroupProcessing = 791,
		StaticCorner = 792,
		StaticCornerCells = 793,
		TablixCorner = 794,
		DataRegionScopedItems = 795,
		NextLeaf = 796,
		PrevLeaf = 797,
		GroupExprValues = 798,
		TargetScopeMatched = 799,
		MemberObjs = 800,
		HasInnerHierarchy = 801,
		FirstPassCellNonCustomAggs = 802,
		FirstPassCellCustomAggs = 803,
		CellsList = 804,
		GroupLeafIndex = 805,
		ProcessHeading = 806,
		MemberInstance = 807,
		SequentialMemberIndexWithinScopeLevel = 808,
		OutermostColumnIndexes = 809,
		OutermostRowIndexes = 810,
		CellRunningValueValues = 811,
		HeadingReportItemCol = 812,
		GroupScopedItems = 813,
		SortInfo = 814,
		SortIndex = 815,
		ValidAggregateRow = 816,
		ContainedType = 817,
		IsValueReady = 818,
		IsVisited = 819,
		Array = 820,
		Keys = 821,
		BucketSize = 822,
		Buckets = 823,
		Version = 824,
		Entries = 825,
		Prime = 826,
		HashInputA = 827,
		HashInputB = 828,
		NodeCapacity = 829,
		ValuesCapacity = 830,
		Comparer = 831,
		Root = 832,
		UseFixedReferences = 833,
		Depth = 834,
		SortTreeNodes = 835,
		PreviousValues = 836,
		StartIndex = 837,
		PreviousEnabled = 838,
		HasNoExplicitScope = 839,
		StaticCellRunningValues = 840,
		CellPreviousValues = 841,
		StaticCellPreviousValues = 842,
		DetailRowIndex = 843,
		DetailUserSortTargetInfo = 844,
		InstanceIndex = 845,
		RecursiveParentIndexes = 846,
		IsOuterGrouping = 847,
		State = 848,
		Fixed = 849,
		SpanSize = 850,
		DefIndex = 851,
		MemberCell = 852,
		DeltaX = 853,
		DeltaY = 854,
		ItemPageSizes = 855,
		ItemsAbove = 856,
		ItemsLeft = 857,
		RPLElement = 858,
		RPLState = 859,
		NonSharedOffset = 860,
		TextBoxValues = 861,
		Indexes = 862,
		Padding = 863,
		DefPadding = 864,
		BodySource = 865,
		ChildBody = 866,
		InvalidImage = 867,
		ImageProps = 868,
		HorizontalPadding = 869,
		VerticalPadding = 870,
		ValueStart = 871,
		ValueEnd = 872,
		CanvasFont = 873,
		CalcSizeState = 874,
		HorizontalState = 875,
		VerticalState = 876,
		TablixState = 877,
		StartPos = 878,
		RPLTablixRow = 879,
		DetailCells = 880,
		SourceHeight = 881,
		RowHeight = 882,
		BodyRows = 883,
		BodyRowHeights = 884,
		BodyColWidths = 885,
		RowMembersDepth = 886,
		ColMembersDepth = 887,
		RowMemberDef = 888,
		RowMemberDefIndexes = 889,
		ColMemberDef = 890,
		ColMemberDefIndexes = 891,
		CellPageBreaks = 892,
		HeaderRowCols = 893,
		HeaderColumnRows = 894,
		RowMemberIndexCell = 895,
		ColMemberIndexCell = 896,
		ColsBeforeRowHeaders = 897,
		ColumnHeaders = 898,
		ColumnHeadersHeights = 899,
		RowHeaders = 900,
		RowHeadersWidths = 901,
		DetailRows = 902,
		CornerCells = 903,
		GroupPageBreaks = 904,
		ColumnInfo = 905,
		IgnoreCol = 906,
		IgnoreRow = 907,
		ContentOnPage = 908,
		CellItem = 909,
		MemberItem = 910,
		CurrRowSpan = 911,
		CurrColSpan = 912,
		MemberState = 913,
		SourceIndex = 914,
		Span = 915,
		MemberInstances = 916,
		RepeatWith = 917,
		IsSimple = 918,
		ConsumeContainerWhitespace = 919,
		FloatValue = 920,
		DateTimeValue = 921,
		ConstantType = 922,
		DataValueSequenceRendering = 923,
		CommonSubReportInfo = 924,
		CommonSubReportInfos = 925,
		DefinitionUniqueName = 926,
		FirstInstanceSet = 927,
		VariablesInScope = 928,
		FlattenedDatasetDependencyMatrix = 929,
		FirstDataSetIndexToProcess = 930,
		SnapshotParameters = 931,
		UserProfileState = 932,
		SequenceID = 933,
		TextboxesInScope = 934,
		GaugePanel = 935,
		GaugeMember = 936,
		GaugeRowMember = 937,
		GaugeRow = 938,
		GaugeCell = 939,
		TransparentColor = 940,
		HueColor = 941,
		OffsetX = 942,
		OffsetY = 943,
		Transparency = 944,
		ClipImage = 945,
		FrameStyle = 946,
		FrameShape = 947,
		FrameWidth = 948,
		GlassEffect = 949,
		FrameBackground = 950,
		FrameImage = 951,
		AllowUpsideDown = 952,
		RotateLabels = 953,
		TickMarkStyle = 954,
		BackFrame = 955,
		ClipContent = 956,
		TopImage = 957,
		MinPercent = 958,
		MaxPercent = 959,
		AddConstant = 960,
		LinearGauges = 961,
		RadialGauges = 962,
		NumericIndicators = 963,
		StateIndicators = 964,
		GaugeImages = 965,
		GaugeLabels = 966,
		AntiAliasing = 967,
		AutoLayout = 968,
		ShadowIntensity = 969,
		TextAntiAliasingQuality = 970,
		ParentItem = 971,
		GaugeInputValue = 972,
		BarStart = 973,
		DistanceFromScale = 974,
		PointerImage = 975,
		MarkerLength = 976,
		MarkerStyle = 977,
		SnappingEnabled = 978,
		SnappingInterval = 979,
		ScaleRanges = 980,
		CustomLabels = 981,
		Logarithmic = 982,
		LogarithmicBase = 983,
		MaximumValue = 984,
		MinimumValue = 985,
		Multiplier = 986,
		GaugeMajorTickMarks = 987,
		GaugeMinorTickMarks = 988,
		MaximumPin = 989,
		MinimumPin = 990,
		ScaleLabels = 991,
		TickMarksOnTop = 992,
		Orientation = 993,
		Thermometer = 994,
		StartMargin = 995,
		EndMargin = 996,
		Placement = 997,
		RotateLabel = 998,
		UseFontPercent = 999,
		CapImage = 1000,
		OnTop = 1001,
		Reflection = 1002,
		CapStyle = 1003,
		GaugeScales = 1004,
		PivotX = 1005,
		PivotY = 1006,
		PointerCap = 1007,
		NeedleStyle = 1008,
		GaugePointers = 1009,
		Radius = 1010,
		StartAngle = 1011,
		SweepAngle = 1012,
		FontAngle = 1013,
		ShowEndLabels = 1014,
		Enable = 1015,
		PinLabel = 1016,
		StartValue = 1017,
		EndValue = 1018,
		StartWidth = 1019,
		EndWidth = 1020,
		InRangeBarPointerColor = 1021,
		InRangeLabelColor = 1022,
		InRangeTickMarksColor = 0x3FF,
		BackgroundGradientType = 0x400,
		BulbOffset = 1025,
		BulbSize = 1026,
		ThermometerStyle = 1027,
		EnableGradient = 1028,
		GradientDensity = 1029,
		TickMarkImage = 1030,
		ResizeMode = 1031,
		TextShadowOffset = 1032,
		Items = 1033,
		Flags = 1034,
		UseRPLStream = 1035,
		RPLSource = 1036,
		GenerationIndex = 1037,
		ToggleParent = 1038,
		IsDefaultLine = 1039,
		RowHeaderWidth = 1040,
		ColumnHeaderHeight = 1041,
		RTL = 1042,
		DateTimeOffsetValue = 1043,
		DetailRowCounter = 1044,
		DetailSortAdditionalGroupLeafs = 1045,
		ProcessStaticCellsForRVs = 1046,
		Arguments = 1047,
		ChartMember = 1048,
		SourceSeries = 1049,
		ExplicitAltReportItem = 1050,
		TextOrientation = 1051,
		AspectRatio = 1052,
		ChartElementPosition = 1053,
		ChartInnerPlotPosition = 1054,
		Disabled = 1055,
		DependencyRefList = 1056,
		RecursiveMember = 1057,
		HasRecursiveChildren = 1058,
		DefinitionHasDocumentMap = 1059,
		Paragraphs = 1060,
		Paragraph = 1061,
		TextBox = 1062,
		TextRuns = 1063,
		TextRun = 1064,
		LeftIndent = 1065,
		RightIndent = 1066,
		HangingIndent = 1067,
		SpaceBefore = 1068,
		SpaceAfter = 1069,
		ListStyle = 1070,
		ListLevel = 1071,
		MarkupType = 1072,
		HasExpressionBasedValue = 1073,
		HasValue = 1074,
		TextRunValueReferenced = 1075,
		ParagraphNumber = 1076,
		ParagraphIndex = 1077,
		TextRunIndex = 1078,
		CharacterIndex = 1079,
		ContentOffset = 1080,
		ContentBottom = 1081,
		PageStartOffset = 1082,
		PageEndOffset = 1083,
		NextPageStartOffset = 1084,
		FirstLine = 1085,
		TopPadding = 1086,
		InDataRowSortPhase = 1087,
		SortedDataRowTree = 1088,
		DataRowSortExpression = 1089,
		PaletteHatchBehavior = 1090,
		ContentHeight = 1091,
		DependencyIndexList = 1092,
		EventSourceColScope = 1093,
		DetailColScopes = 1094,
		HasNonRecursiveSender = 1095,
		IsDataRegion = 1096,
		OriginalCatalogPath = 1097,
		Lookups = 1098,
		LookupDestinations = 1099,
		SourceExpr = 1100,
		DestinationExpr = 1101,
		ResultExpr = 1102,
		DestinationIndexInCollection = 1103,
		UsedInSameDataSetTablixProcessing = 1104,
		UsedInSameDataSetFirstPass = 1105,
		HasSameDataSetLookups = 1106,
		FirstRowOffset = 1107,
		RowOffsets = 1108,
		Rows = 1109,
		LookupResults = 1110,
		HasLookups = 1111,
		TreePartitionOffsets = 1112,
		GroupTreePartitions = 1113,
		LookupPartitions = 1114,
		LookupTablePartitionID = 1115,
		NeedsTotalPages = 1116,
		NeedsReportItemsOnPage = 1117,
		ReportSections = 1118,
		PrintBetweenSections = 1119,
		HasHeadersOrFooters = 1120,
		LastAssignedGlobalID = 1121,
		ContainingSection = 1122,
		LookupType = 1123,
		ExceptionMessage = 1124,
		Map = 1125,
		MapDataRegions = 1126,
		MapDataRegion = 1127,
		MapMember = 1128,
		MapRowMember = 1129,
		MapRow = 1130,
		MapCell = 1131,
		Unit = 1132,
		ShowLabels = 1133,
		LabelPosition = 1134,
		MapLocation = 1135,
		MapSize = 1136,
		DockOutsideViewport = 1137,
		FieldName = 1138,
		BindingExpression = 1139,
		LayerName = 1140,
		MapBindingFieldPairs = 1141,
		ZoomEnabled = 1142,
		MapCoordinateSystem = 1143,
		MapProjection = 1144,
		ProjectionCenterX = 1145,
		ProjectionCenterY = 1146,
		MaximumZoom = 1147,
		MinimumZoom = 1148,
		MapLimits = 1149,
		ContentMargin = 1150,
		MapMeridians = 1151,
		MapParallels = 1152,
		GridUnderContent = 1153,
		MinimumX = 1154,
		MinimumY = 1155,
		MaximumX = 1156,
		MaximumY = 1157,
		LimitToData = 1158,
		MapColorScaleTitle = 1159,
		TickMarkLength = 1160,
		ColorBarBorderColor = 1161,
		LabelFormat = 1162,
		LabelPlacement = 1163,
		LabelBehavior = 1164,
		RangeGapColor = 1165,
		NoDataText = 1166,
		ScaleColor = 1167,
		ScaleBorderColor = 1168,
		TitleSeparatorColor = 1169,
		MapLegendTitle = 1170,
		DistributionType = 1171,
		BucketCount = 1172,
		MapBuckets = 1173,
		StartColor = 1174,
		MiddleColor = 1175,
		EndColor = 1176,
		ShowInColorScale = 1177,
		MapSizeRule = 1178,
		MapColorRule = 1179,
		MapPointRules = 1180,
		StartSize = 1181,
		EndSize = 1182,
		MapMarkerStyle = 1183,
		MapMarkerlImage = 1184,
		MapMarkers = 1185,
		MapMarkerRule = 1186,
		DataValue = 1187,
		MapCustomColors = 1188,
		ScaleFactor = 1189,
		CenterPointOffsetX = 1190,
		CenterPointOffsetY = 1191,
		ShowLabel = 1192,
		MapMarker = 1193,
		ReportItem = 1194,
		MapLegend = 1195,
		UseCustomLineTemplate = 1196,
		UseCustomPolygonTemplate = 1197,
		UseCustomPointTemplate = 1198,
		VectorData = 1199,
		MapFields = 1200,
		MapPolygonTemplate = 1201,
		MapPointTemplate = 1202,
		MapLineTemplate = 1203,
		VisibilityMode = 1204,
		MapLineRules = 1205,
		MapLines = 1206,
		MapFieldNames = 1207,
		SimplificationResolution = 1208,
		MapPolygons = 1209,
		SpatialField = 1210,
		TileData = 1211,
		ServiceUrl = 1212,
		TileStyle = 1213,
		MapTiles = 1214,
		MapDataRegionName = 1215,
		MapFieldDefinitions = 1216,
		MapSpatialData = 1217,
		MapPolygonRules = 1218,
		MapPoints = 1219,
		MapViewport = 1220,
		MapLayers = 1221,
		MapLegends = 1222,
		MapTitles = 1223,
		MapDistanceScale = 1224,
		MapColorScale = 1225,
		MapBorderSkin = 1226,
		MaximumSpatialElementCount = 1227,
		MaximumTotalPointCount = 1228,
		MapBorderSkinType = 1229,
		ExprHostMapMemberID = 1230,
		CenterX = 1231,
		CenterY = 1232,
		Zoom = 1233,
		MapView = 1234,
		MapVectorLayer = 1235,
		CachedShapefiles = 1236,
		DataElementLabel = 1237,
		TileLanguage = 1238,
		CurrentUnion = 1239,
		UseSecureConnection = 1240,
		NeedsOverallTotalPages = 1241,
		NeedsPageBreakTotalPages = 1242,
		AutoRefreshExpression = 1243,
		PageBreak = 1244,
		ResetPageNumber = 1245,
		PageName = 1246,
		InitialPageName = 1247,
		PageBreakProperties = 1248,
		PageBreakPropertiesAtStart = 1249,
		PageBreakPropertiesAtEnd = 1250,
		UpdatedVariableValues = 1251,
		Writable = 1252,
		SerializableVariables = 1253,
		DocumentMapRenderFormat = 1254,
		AggregatesOfAggregates = 1255,
		PostSortAggregatesOfAggregates = 1256,
		RunningValuesOfAggregates = 1257,
		HasAggregatesOfAggregates = 1258,
		DataScopeInfo = 1259,
		AggregatesSpanGroupFilter = 1260,
		MaxAggregateOfAggregatesLevel = 1261,
		InnermostUpdateScope = 1262,
		NumericIndicatorRanges = 1263,
		DecimalDigitColor = 1264,
		DigitColor = 1265,
		DecimalDigits = 1266,
		Digits = 1267,
		NonNumericString = 1268,
		OutOfRangeString = 1269,
		ShowDecimalPoint = 1270,
		ShowLeadingZeros = 1271,
		IndicatorStyle = 1272,
		ShowSign = 1273,
		LedDimColor = 1274,
		SeparatorWidth = 1275,
		IndicatorImage = 1276,
		IndicatorStates = 1277,
		UpdateScopeID = 1278,
		UpdateScopeDepth = 1279,
		UpdatesAtRowScope = 1280,
		ScopeID = 1281,
		HasAggregatesToUpdateAtRowScope = 1282,
		RunningValueOfAggregateValues = 1283,
		HasAggregatesOfAggregatesInUserSort = 1284,
		CanonicalCellScope = 1285,
		DomainScope = 1286,
		ScopeIDForDomainScope = 1287,
		InnerDomainScopeCount = 1288,
		RowDomainScopeCount = 1289,
		ColumnDomainScopeCount = 1290,
		OriginalScopeID = 1291,
		TransformationType = 1292,
		TransformationScope = 1293,
		StateDataElementName = 1294,
		StateDataElementOutput = 1295,
		FieldNames = 1296,
		SharedDataSetQuery = 1297,
		OriginalSharedDataSetReference = 1298,
		DataSetCore = 1299,
		CatalogID = 1300,
		ExprHostAssemblyID = 1301,
		SharedDSContainerCollectionIndex = 1302,
		IsArtificialDataSource = 1303,
		ReadOnly = 1304,
		OmitFromQuery = 1305,
		ParameterType = 1306,
		DataRowHolder = 1307,
		Cells2 = 1308,
		MemberAtLevelIndexes = 1309,
		ScopeValue = 1310,
		CanScroll = 1311,
		CanScrollVertically = 1312,
		NaturalGroup = 1313,
		LastValue = 1314,
		Relationships = 1315,
		ParentScope = 1316,
		RelatedDataSet = 1317,
		JoinConditions = 1318,
		ForeignKeyExpression = 1319,
		PrimaryKeyExpression = 1320,
		NaturalSort = 1321,
		BandLayout = 1322,
		LabelData = 1323,
		Play = 1324,
		DockingOption = 1325,
		ReportItemReference = 1326,
		Slider = 1327,
		Navigation = 1328,
		BandNavigationCell = 1329,
		IsDecomposable = 1330,
		AllowIncrementalProcessing = 1331,
		NavigationItem = 1332,
		NaturalSortFlags = 1333,
		MemberGroupAndSortExpressionFlag = 1334,
		ScopeIDContent = 1335,
		ScopeIDInfo = 1336,
		DefaultRelationships = 1337,
		ParentDataSet = 1338,
		NeedsIDC = 1339,
		RowMemberInstanceIndexes = 1340,
		NaturalJoin = 1341,
		ExactRowHeight = 1342,
		IgnoreRowHeight = 1343,
		BottomPadding = 1344,
		TopBorder = 1345,
		BottomBorder = 1346,
		LeftBorder = 1347,
		RightBorder = 1348,
		Footer = 1349,
		FirstPageHeader = 1350,
		FirstPageFooter = 1351,
		HighlightY = 1352,
		ScopeInstanceNumber = 1353,
		JoinInfo = 1354,
		RowParentDataSet = 1355,
		ColumnParentDataSet = 1356,
		IsMatrixIDC = 1357,
		DataPipelineID = 1358,
		DataPipelineCount = 1359,
		HighlightX = 1360,
		HighlightSize = 1361,
		AggregateIndicatorFieldIndex = 1362,
		HasScopeWithCustomAggregates = 1363,
		GroupingFieldIndicesForServerAggregates = 1364,
		HasProcessedAggregateRow = 1365,
		ColumnGroupingIsSwitched = 1366,
		RdlFunctionType = 1367,
		RdlFunctionInfo = 1368,
		NullsAsBlanks = 1369,
		CollationCulture = 1370,
		Tag = 1371,
		TagTypeCode = 1372,
		DeferredSortFlags = 1373,
		DeferredSort = 1374,
		EmbeddingMode = 1375,
		ValueType = 1376,
		EnableRowDrilldown = 1377,
		EnableColumnDrilldown = 1378,
		ScopedFieldInfo = 1379,
		FieldIndex = 1380,
		EnableCategoryDrilldown = 1381,
		BackgroundRepeat = 1382,
		KeyFields = 1383,
		Tags = 1384,
		FormatX = 1385,
		FormatY = 1386,
		FormatSize = 1387,
		CurrencyLanguageX = 1388,
		CurrencyLanguageY = 1389,
		CurrencyLanguageSize = 1390,
		CurrencyLanguage = 1391,
		ParametersLayout = 1392,
		ParametersGridLayoutDefinition = 1393,
		ParametersLayoutCellDefinitions = 1394,
		ParametersLayoutNumberOfColumns = 1395,
		ParametersLayoutNumberOfRows = 1396,
		ParameterLayoutCellDefinition = 1397,
		ParameterCellRowIndex = 1398,
		ParameterCellColumnIndex = 1399,
		ParameterName = 1400,
		DefaultFontFamily = 1401
	}
}
