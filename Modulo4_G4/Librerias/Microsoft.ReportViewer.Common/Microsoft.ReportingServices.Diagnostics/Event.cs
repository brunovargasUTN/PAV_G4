namespace Microsoft.ReportingServices.Diagnostics
{
	internal enum Event
	{
		SqlAgentNotRunning = 106,
		CouldNotCommunicateToCatalog,
		CouldNotLoadExtension,
		ConfigFileChanged,
		InvalidConfigEntry,
		CouldNotCreateTraceFile,
		DenialOfService,
		CantCreatePerfCounters,
		CantCommunicateToReportServer,
		ScheduleUpdated,
		InternalError,
		InvalidDBVersion,
		TraceNotDefaultLocation,
		NotActivated,
		IsDisabled,
		RPCFailedStart,
		InvalidSMTP,
		FailedTraceWrite,
		ActivationSuccessful,
		KeyExtractionSuccessful,
		KeyImportSuccessful,
		EncryptDataCleaned,
		SKUMismatch,
		FailedToDecryptDSN,
		ConfigFileNotFound,
		FailureToDecryptData,
		FailureToEncryptData,
		FailureToLoadConfigFile,
		FailureToEncryptConfigData,
		KeyDeleteSuccessful,
		EvaluationPeriodExpired,
		SetExtensionConfigFailed,
		WebFarmNodeActivated,
		AppDomainFailedToStart,
		AppDomainFailedToInitialize,
		AppDomainMaxMemoryLimitReached,
		PollQueueFull,
		ServerStarted,
		ServerFailedToStart,
		ServerStopped,
		ServerFailedToStop
	}
}