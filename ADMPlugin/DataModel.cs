using System;
using System.Collections.Generic;
using System.Text;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin
{
    public class DataModel
    {
        private static DataModel _instance;
        private static readonly object _instanceThreadLock = new object();
        private static bool _useDefaults = false;

        private RuntimeTypeModel _model;

        public RuntimeTypeModel Model => _model;

        private DataModel()
        {
            _model = CreateModel();
        }

        public static DataModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceThreadLock)
                    {
                        if (_instance == null)
                            _instance = new DataModel();
                    }
                }
                return _instance;
            }
        }

        private RuntimeTypeModel CreateModel()
        {
            var model = RuntimeTypeModel.Create();

            // Common
            AddContextItemDefinition(model);
            AddContextItemEnumItem(model);
            AddGeoPoliticalContext(model);
            AddLanguage(model);
            AddLexicalization(model);
            AddModelScope(model);
            AddPresentation(model);
            AddCompoundIdentifier(model);
            AddContextItem(model);
            AddTimeScope(model);
            AddUniqueId(model);
            AddUnitOfMeasure(model);

            // Documents
            AddMeteredValue(model);
            AddOperationSummary(model);
            AddStampedMeteredValues(model);
            AddSummary(model);
            AddDocument(model);
            AddDocumentCorrelation(model);
            AddPlan(model);
            AddRecommendation(model);
            AddStatusUpdate(model);
            AddWorkItem(model);
            AddWorkItemOperation(model);
            AddWorkOrder(model);
            AddWorkRecord(model);

            // Equipment
            AddDeviceElement(model);
            AddDeviceElementConfiguration(model);
            AddDeviceModel(model);
            AddEquipmentConfigurationGroup(model);
            AddHitchPoint(model);
            AddImplementConfiguration(model);
            AddMachineConfiguration(model);
            AddSectionConfiguration(model);
            AddConnector(model);
            AddEquipmentConfiguration(model);
            AddReferencePoint(model);
            AddDeviceElementUse(model);

            // Guidance
            AddGuidancePattern(model);
            AddAbCurve(model);
            AddAbLine(model);
            AddMultiAbLine(model);
            AddAPlus(model);
            AddPivotGuidancePattern(model);
            AddGuidanceAllocation(model);
            AddGuidanceGroup(model);
            AddGuidanceShift(model);
            AddSpiral(model);

            // Logistics
            AddCropZone(model);
            AddBrand(model);
            AddCompany(model);
            AddContact(model);
            AddContactInfo(model);
            AddFacility(model);
            AddFarm(model);
            AddField(model);
            AddGpsSource(model);
            AddGrower(model);
            AddLocation(model);
            AddDestination(model);
            AddManufacturer(model);
            AddPermittedProduct(model);
            AddPerson(model);
            AddPersonRole(model);

            // Prescriptions
            AddRxProductLookup(model);
            AddPrescription(model);
            AddManualPrescription(model);
            AddSpatialPrescription(model);
            AddRasterGridPrescription(model);
            AddRxRate(model);
            AddRxRates(model);
            AddRxShapeLookup(model);
            AddVectorPrescription(model);

            // Products
            AddIngredient(model);
            AddAvailableProduct(model);
            AddProduct(model);
            AddHarvestedCommodityProduct(model);
            AddCrop(model);
            AddCropNutritionIngredient(model);
            AddCropProtectionProduct(model);
            AddCropVarietyProduct(model);
            AddDensityFactor(model);
            AddCropNutritionProduct(model);
            AddIngredientUse(model);
            AddProductComponent(model);
            AddMixProduct(model);
            AddProductUse(model);
            AddTrait(model);

            // ADM
            AddApplicationDataModel(model);
            AddDocuments(model);
            AddProperties(model);
            AddProprietaryValue(model);
            AddCatalog(model);

            // Shapes
            AddBoundingBox(model);
            AddShape(model);
            AddLinearRing(model);
            AddLineString(model);
            AddMultiLineString(model);
            AddMultiPoint(model);
            AddMultiPolygon(model);
            AddPoint(model);
            AddPolygon(model);

            // LoggedData
            AddCalibrationFactor(model);
            AddDataLogTrigger(model);
            AddWorkingData(model);
            AddEnumeratedWorkingData(model);
            AddLoad(model);
            AddLoggedData(model);
            AddNumericWorkingData(model);
            AddOperationData(model);
            AddSectionSummary(model);
            AddSpatialRecord(model);

            // FieldBoundaries
            AddHeadland(model);
            AddConstantOffsetHeadland(model);
            AddDrivenHeadland(model);
            AddFieldBoundary(model);
            AddInteriorBoundaryAttribute(model);

            // Representations
            AddEnumerationMember(model);
            AddRepresentation(model);
            AddEnumeratedRepresentation(model);
            AddEnumeratedRepresentationGroup(model);
            AddRepresentationValue(model);
            AddEnumeratedValue(model);
            AddNumericValue(model);
            AddNumericRepresentation(model);
            AddNumericRepresentationValue(model);
            AddStringRepresentation(model);
            AddStringValue(model);

            // Notes
            AddNote(model);

            // ReferenceLayers
            AddReferenceLayer(model);
            AddRasterReferenceLayer(model);
            AddShapeLookup(model);
            AddShapeReferenceLayer(model);
            AddSpatialAttribute(model);
            AddRasterDataEnumerated(model);
            AddRasterDataString(model);
            AddRasterDataNumeric(model);
            AddSerializableRasterDataEnumeration(model);
            AddSerializableRasterDataString(model);
            AddSerializableRasterDataNumeric(model);
            AddSerializableReferenceLayer(model);

            return model;
        }

        #region ADM

        private void AddApplicationDataModel(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ApplicationDataModel.ADM.ApplicationDataModel), _useDefaults);
            type.Add(167, "ProprietaryValues");
            type.Add(168, "Catalog");
            type.Add(169, "Documents");
            type.Add(170, "ReferenceLayers");
        }

        private void AddDocuments(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Documents), _useDefaults);
            type.Add(171, "WorkItems");
            type.Add(172, "WorkItemOperations");
            type.Add(173, "LoggedData");
            type.Add(174, "Plans");
            type.Add(175, "WorkOrders");
            type.Add(691, "WorkRecords");
            type.Add(176, "Recommendations");
            type.Add(177, "GuidanceAllocations");
            type.Add(178, "Summaries");
            type.Add(179, "LoggedDataCatalog");
            type.Add(826, "DeviceElementUses");
        }

        private void AddProperties(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Properties), _useDefaults);
            type.Add(180, "_properties");
        }

        private void AddProprietaryValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ProprietaryValue), _useDefaults);
            type.Add(181, "Key");
            type.Add(182, "Value");
        }


        private void AddCatalog(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Catalog), _useDefaults);
            type.Add(183, "Brands");
            type.Add(692, "Companies");
            type.Add(184, "Connectors");
            type.Add(185, "ContactInfo");
            type.Add(187, "Crops");
            type.Add(190, "CropZones");
            type.Add(191, "Description");
            type.Add(505, "DeviceElements");
            type.Add(506, "DeviceModels");
            type.Add(507, "DeviceElementConfigurations");
            type.Add(599, "EquipmentConfigurations");
            type.Add(600, "EquipmentConfigurationGroups");
            type.Add(193, "Farms");
            type.Add(195, "Fields");
            type.Add(196, "FieldBoundaries");
            type.Add(197, "Growers");
            type.Add(198, "GuidancePatterns");
            type.Add(199, "GuidanceGroups");
            type.Add(508, "HitchPoints");
            type.Add(204, "Ingredients");
            type.Add(210, "Manufacturers");
            type.Add(211, "Persons");
            type.Add(212, "PersonRoles");
            type.Add(213, "Prescriptions");
            type.Add(693, "Products");
            type.Add(215, "TimeScopes");
        }

        #endregion ADM

        #region Common

        private void AddContextItemDefinition(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ContextItemDefinition), _useDefaults);
            type.Add(552, "Id");
            type.Add(553, "ParentId");
            type.Add(554, "Code");
            type.Add(555, "Version");
            type.Add(556, "ValueType");
            type.Add(557, "Description");
            type.Add(558, "Keywords");
            type.Add(559, "AgGlossaryURL");
            type.Add(560, "AgrovocURL");
            type.Add(561, "Lexicalizations");
            type.Add(562, "Properties");
            type.Add(563, "NestedDefIds");
            type.Add(564, "Presentations");
            type.Add(565, "EnumItems");
            type.Add(566, "DefaultUOM");
            type.Add(567, "AllowConversion");
            type.Add(568, "TimeScopes");
            type.Add(569, "ModelScopeIds");
            type.Add(570, "GeoPoliticalContextIds");
        }

        private void AddContextItemEnumItem(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ContextItemEnumItem), _useDefaults);
            type.Add(571, "Value");
            type.Add(572, "Version");
            type.Add(573, "Description");
            type.Add(574, "AgGlossaryURL");
            type.Add(575, "AgrovocURL");
            type.Add(576, "Lexicalizations");
            type.Add(577, "Properties");
        }

        private void AddGeoPoliticalContext(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(GeoPoliticalContext), _useDefaults);
            type.Add(578, "Id");
            type.Add(579, "Code");
            type.Add(580, "Description");
        }

        private void AddLanguage(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Language), _useDefaults);
            type.Add(581, "Id");
            type.Add(582, "Code");
            type.Add(583, "Description");
        }

        private void AddLexicalization(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Lexicalization), _useDefaults);
            type.Add(584, "Text");
            type.Add(585, "LanguageId");
            type.Add(586, "GeoPoliticalContextIds");
        }

        private void AddModelScope(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ModelScope), _useDefaults);
            type.Add(587, "Id");
            type.Add(588, "Code");
            type.Add(589, "Description");
            type.Add(590, "ModelScopeType");
        }

        private void AddPresentation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Presentation), _useDefaults);
            type.Add(591, "Description");
            type.Add(592, "EntryFormatRegEx");
            type.Add(593, "DisplayFormatRegEx");
            type.Add(594, "GeoPoliticalContextIds");
        }

        private void AddCompoundIdentifier(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CompoundIdentifier), _useDefaults);
            type.Add(87, "ReferenceId");
            type.Add(88, "UniqueIds");
        }

        private void AddContextItem(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ContextItem), _useDefaults);
            type.Add(595, "Code");
            type.Add(90, "Value");
            type.Add(596, "ValueUOM");
            type.Add(597, "NestedItems");
            type.Add(498, "TimeScopes");
        }

        private void AddTimeScope(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(TimeScope), _useDefaults);
            type.Add(95, "Id");
            type.Add(96, "Description");
            type.Add(499, "DateContext");
            type.Add(500, "TimeStamp1");
            type.Add(501, "TimeStamp2");
            type.Add(502, "Location1");
            type.Add(503, "Location2");
            type.Add(504, "Duration");
        }

        private void AddUniqueId(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(UniqueId), _useDefaults);
            type.Add(99, "Id");
            type.Add(820, "IdType");
            type.Add(101, "Source");
            type.Add(102, "SourceType");
        }

        private void AddUnitOfMeasure(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(UnitOfMeasure), _useDefaults);
            type.Add(103, "Id");
            type.Add(104, "Code");
            type.Add(105, "Dimension");
            type.Add(106, "IsReferenceForDimension");
            type.Add(107, "Scale");
            type.Add(108, "Offset");
        }

        #endregion Common

        #region Documents

        private void AddMeteredValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MeteredValue), _useDefaults);
            type.Add(509, "Value");
            type.Add(510, "MeterId");
        }

        private void AddOperationSummary(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(OperationSummary), _useDefaults);
            type.Add(831, "Id");
            type.Add(511, "OperationType");
            type.Add(512, "ProductId");
            type.Add(513, "WorkItemOperationId");
            type.Add(514, "Data");
            type.Add(832, "EquipmentConfigurationIds");
            type.Add(833, "CoverageShape");
            type.Add(834, "ContextItems");

        }

        private void AddStampedMeteredValues(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(StampedMeteredValues), _useDefaults);
            type.Add(682, "Values");
            type.Add(683, "Stamp");
        }

        private void AddSummary(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Summary), _useDefaults);
            type.Add(835, "Id");
            type.Add(836, "WorkRecordId");
            type.Add(837, "GrowerId");
            type.Add(684, "FarmId");
            type.Add(685, "FieldId");
            type.Add(686, "CropZoneId");
            type.Add(838, "TimeScopes");
            type.Add(520, "PersonRoleIds");
            type.Add(602, "EquipmentConfigurationGroup");
            type.Add(839, "GuidanceAllocationIds");
            type.Add(524, "WorkItemIds");
            type.Add(523, "LoggedDataIds");
            type.Add(522, "Notes");
            type.Add(516, "SummaryData");
            type.Add(525, "OperationSummaries");
        }

        private void AddDocument(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Document), _useDefaults);
            type.Add(355, "Id");
            type.Add(356, "ContextItems");
            type.Add(357, "CropIds");
            type.Add(358, "CropZoneIds");
            type.Add(359, "Description");
            type.Add(360, "EstimatedArea");
            type.Add(361, "FarmIds");
            type.Add(362, "FieldIds");
            type.Add(363, "GrowerId");
            type.Add(364, "Notes");
            type.Add(365, "PersonRoleIds");
            type.Add(821, "TimeScopes");
            type.Add(367, "Version");

            type.AddSubType(223, typeof(Plan));
            type.AddSubType(224, typeof(Recommendation));
            type.AddSubType(253, typeof(WorkOrder));
            type.AddSubType(222, typeof(WorkRecord));
        }

        private void AddDocumentCorrelation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DocumentCorrelation), _useDefaults);
            type.Add(216, "Id");
            type.Add(217, "RelationshipType");
            type.Add(218, "DocumentId");
            type.Add(527, "OriginatingDocumentId");
            type.Add(328, "TimeScopes");
            type.Add(221, "PersonRoleIds");
        }

        private void AddPlan(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Plan), _useDefaults);
            type.Add(528, "WorkItemIds");
        }

        private void AddRecommendation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Recommendation), _useDefaults);
            type.Add(529, "WorkItemIds");
        }

        private void AddStatusUpdate(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(StatusUpdate), _useDefaults);
            type.Add(225, "Status");
            type.Add(530, "Note");
            type.Add(227, "TimeStamp");
        }

        private void AddWorkItem(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(WorkItem), _useDefaults);
            type.Add(228, "Id");
            type.Add(232, "Notes");
            type.Add(822, "TimeScopes");
            type.Add(233, "WorkItemPriority");
            type.Add(235, "PeopleRoleIds");
            type.Add(236, "GrowerId");
            type.Add(237, "FarmId");
            type.Add(238, "FieldId");
            type.Add(239, "CropZoneId");
            type.Add(241, "ReferenceLayerIds");
            type.Add(242, "BoundaryId");
            type.Add(243, "WorkItemOperationIds");
            type.Add(244, "GuidanceAllocationIds");
            type.Add(245, "StatusUpdates");
            type.Add(231, "WorkOrderIds");
            type.Add(246, "ParentDocumentId");
            type.Add(603, "EquipmentConfigurationGroup");
        }

        private void AddWorkItemOperation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(WorkItemOperation), _useDefaults);
            type.Add(247, "Description");
            type.Add(248, "Id");
            type.Add(249, "OperationType");
            type.Add(250, "PrescriptionId");
            type.Add(604, "EquipmentConfigurationIds");
        }

        private void AddWorkOrder(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(WorkOrder), _useDefaults);
            type.Add(254, "StatusUpdates");
            type.Add(532, "WorkItemIds");
        }

        private void AddWorkRecord(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(WorkRecord), _useDefaults);
            type.Add(605, "LoggedDataIds");
            type.Add(606, "SummariesIds");
        }

        #endregion Documents

        #region Equipment

        private void AddDeviceElement(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DeviceElement), _useDefaults);
            type.Add(607, "Id");
            type.Add(608, "Description");
            type.Add(609, "SerialNumber");
            type.Add(610, "ManufacturerId");
            type.Add(611, "BrandId");
            type.Add(612, "SeriesId");
            type.Add(613, "ContextItems");
            type.Add(614, "DeviceClassification");
            type.Add(615, "DeviceModelId");
            type.Add(616, "DeviceElementType");
            type.Add(617, "ParentDeviceId");
        }

        private void AddDeviceElementConfiguration(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DeviceElementConfiguration), _useDefaults);
            type.Add(618, "Id");
            type.Add(619, "DeviceElementId");
            type.Add(620, "Description");
            type.Add(621, "TimeScopes");
            type.Add(622, "Offsets");

            type.AddSubType(634, typeof(ImplementConfiguration));
            type.AddSubType(644, typeof(MachineConfiguration));
            type.AddSubType(648, typeof(SectionConfiguration));
        }

        private void AddDeviceModel(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DeviceModel), _useDefaults);
            type.Add(623, "Id");
            type.Add(624, "Description");
            type.Add(625, "SeriesId");
            type.Add(626, "BrandId");
        }

        private void AddEquipmentConfigurationGroup(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EquipmentConfigurationGroup), _useDefaults);
            type.Add(627, "Id");
            type.Add(628, "Description");
            type.Add(629, "EquipmentConfigurations");
            type.Add(630, "TimeScopes");
        }

        private void AddHitchPoint(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(HitchPoint), _useDefaults);
            type.Add(631, "Id");
            type.Add(632, "HitchTypeEnum");
            type.Add(840, "ReferencePoint");
        }

        private void AddImplementConfiguration(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ImplementConfiguration), _useDefaults);
            type.Add(635, "Width");
            type.Add(636, "TrackSpacing");
            type.Add(637, "PhysicalWidth");
            type.Add(638, "InGroundTurnRadius");
            type.Add(639, "ImplementLength");
            type.Add(640, "VerticalCuttingEdgeZOffset");
            type.Add(641, "GPSReceiverZOffset");
            type.Add(642, "YOffset");
            type.Add(643, "ControlPoint");
        }

        private void AddMachineConfiguration(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MachineConfiguration), _useDefaults);
            type.Add(645, "GpsReceiverXOffset");
            type.Add(646, "GpsReceiverYOffset");
            type.Add(647, "GpsReceiverZOffset");
        }

        private void AddSectionConfiguration(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SectionConfiguration), _useDefaults);
            type.Add(649, "SectionWidth");
            type.Add(650, "LateralOffset");
            type.Add(651, "InlineOffset");
        }

        private void AddConnector(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Connector), _useDefaults);
            type.Add(652, "Id");
            type.Add(841, "DeviceElementConfigurationId");
            type.Add(654, "HitchPointId");
        }

        private void AddEquipmentConfiguration(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EquipmentConfiguration), _useDefaults);
            type.Add(662, "Id");
            type.Add(663, "Description");
            type.Add(664, "Connector1Id");
            type.Add(665, "Connector2Id");
            type.Add(666, "DataLogTriggers");
        }

        private void AddReferencePoint(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ReferencePoint), _useDefaults);
            type.Add(668, "Id");
            type.Add(669, "XOffset");
            type.Add(670, "YOffset");
            type.Add(671, "ZOffset");
        }

        private void AddDeviceElementUse(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DeviceElementUse), _useDefaults);
            type.Add(672, "Id");
            type.Add(673, "DeviceConfigurationId");
            type.Add(674, "OperationDataId");
            type.Add(675, "Depth");
            type.Add(676, "Order");
            type.Add(677, "TotalDistanceTravelled");
            type.Add(678, "TotalElapsedTime");
        }

        #endregion Equipment

        #region FieldBoundaries

        private void AddHeadland(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Headland), _useDefaults);
            type.Add(694, "Description");

            type.AddSubType(695, typeof(ConstantOffsetHeadland));
            type.AddSubType(697, typeof(DrivenHeadland));
        }

        private void AddConstantOffsetHeadland(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ConstantOffsetHeadland), _useDefaults);
            type.Add(696, "Value");
        }

        private void AddDrivenHeadland(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DrivenHeadland), _useDefaults);
            type.Add(698, "SpatialData");
        }

        private void AddFieldBoundary(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(FieldBoundary), _useDefaults);
            type.Add(699, "Id");
            type.Add(700, "Description");
            type.Add(701, "FieldId");
            type.Add(702, "SpatialData");
            type.Add(827, "TimeScopes");
            type.Add(704, "Headlands");
            type.Add(705, "GpsSource");
            type.Add(706, "OriginalEpsgCode");
            type.Add(707, "InteriorBoundaryAttributes");
            type.Add(708, "ContextItems");
        }

        private void AddInteriorBoundaryAttribute(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(InteriorBoundaryAttribute), _useDefaults);
            type.Add(709, "ShapeIdRef");
            type.Add(710, "IsPassable");
            type.Add(711, "Description");
        }

        #endregion FieldBoundaries

        #region Guidance

        private void AddGuidancePattern(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(GuidancePattern), _useDefaults);
            type.Add(255, "Id");
            type.Add(256, "GuidancePatternType");
            type.Add(257, "GpsSource");
            type.Add(258, "OriginalEpsgCode");
            type.Add(259, "Description");
            type.Add(260, "SwathWidth");
            type.Add(261, "PropagationDirection");
            type.Add(262, "Extension");
            type.Add(263, "NumbersOfSwathsLeft");
            type.Add(264, "NumbersOfSwathsRight");
            type.Add(265, "BoundingPolygon");

            type.AddSubType(266, typeof(AbCurve));
            type.AddSubType(272, typeof(AbLine));
            type.AddSubType(278, typeof(MultiAbLine));
            type.AddSubType(280, typeof(APlus));
            type.AddSubType(842, typeof(PivotGuidancePattern));
            type.AddSubType(304, typeof(Spiral));
        }

        private void AddAbCurve(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(AbCurve), _useDefaults);
            type.Add(267, "NumberOfSegments");
            type.Add(268, "Heading");
            type.Add(269, "EastShiftComponent");
            type.Add(270, "NorthShiftComponent");
            type.Add(271, "Shape");
        }

        private void AddAbLine(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(AbLine), _useDefaults);
            type.Add(273, "A");
            type.Add(274, "B");
            type.Add(275, "Heading");
            type.Add(276, "EastShiftComponent");
            type.Add(277, "NorthShiftComponent");
        }

        private void AddMultiAbLine(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MultiAbLine), _useDefaults);
            type.Add(279, "AbLines");
        }

        private void AddAPlus(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(APlus), _useDefaults);
            type.Add(281, "Point");
            type.Add(282, "Heading");
        }

        private void AddPivotGuidancePattern(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(PivotGuidancePattern), _useDefaults);
            type.Add(843, "StartPoint");
            type.Add(844, "EndPoint");
            type.Add(845, "Center");
        }

        private void AddGuidanceAllocation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(GuidanceAllocation), _useDefaults);
            type.Add(287, "Id");
            type.Add(288, "GuidanceGroupId");
            type.Add(533, "GuidanceShift");
            type.Add(329, "TimeScopes");
        }

        private void AddGuidanceGroup(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(GuidanceGroup), _useDefaults);
            type.Add(294, "Id");
            type.Add(295, "Description");
            type.Add(296, "GuidancePatternIds");
            type.Add(297, "BoundingPolygon");
        }

        private void AddGuidanceShift(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(GuidanceShift), _useDefaults);
            type.Add(298, "GuidanceGroupId");
            type.Add(299, "GuidancePatterId");
            type.Add(300, "EastShift");
            type.Add(301, "NorthShift");
            type.Add(302, "PropagationOffset");
            type.Add(303, "TimeScopeIds");
        }

        private void AddSpiral(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Spiral), _useDefaults);
            type.Add(305, "Shape");
        }

        #endregion Guidance

        #region LoggedData

        private void AddCalibrationFactor(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CalibrationFactor), _useDefaults);
            type.Add(1, "Id");
            type.Add(2, "MeterId");
            type.Add(3, "TimeScopeIds");
            type.Add(4, "Value");
            type.Add(5, "OperationDataId");
        }

        private void AddDataLogTrigger(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DataLogTrigger), _useDefaults);
            type.Add(6, "Id");
            type.Add(7, "DataLogMethod");
            type.Add(8, "DataLogDistanceInterval");
            type.Add(9, "DataLogTimeInterval");
            type.Add(10, "DataLogThresholdMinimum");
            type.Add(11, "DataLogThresholdMaximum");
            type.Add(12, "DataLogThresholdChange");
            type.Add(13, "ContextItems");
            type.Add(14, "LoggingLevel");
            type.Add(15, "Representation");
            type.Add(847, "DeviceElementId");
        }

        private void AddWorkingData(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(WorkingData), _useDefaults);
            type.Add(476, "Id");
            type.Add(477, "DeviceElementUseId");
            type.Add(478, "Representation");
            type.Add(479, "AppliedLatency");
            type.Add(480, "ReportedLatency");

            type.AddSubType(482, typeof(EnumeratedWorkingData));
            type.AddSubType(488, typeof(NumericWorkingData));
        }

        private void AddEnumeratedWorkingData(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EnumeratedWorkingData), _useDefaults);
            type.Add(483, "ValueCodes");
        }

        private void AddLoad(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Load), _useDefaults);
            type.Add(26, "Id");
            type.Add(27, "Description");
            type.Add(28, "TimeScopeIds");
            type.Add(29, "LoadNumber");
            type.Add(30, "LoadType");
            type.Add(31, "LoadQuality");
            type.Add(32, "DestinationIds");
        }

        private void AddLoggedData(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(LoggedData), _useDefaults);
            type.Add(689, "Id");
            type.Add(848, "WorkRecordId");
            type.Add(679, "GrowerId");
            type.Add(52, "FarmId");
            type.Add(53, "FieldId");
            type.Add(54, "CropZoneId");
            type.Add(680, "TimeScopes");
            type.Add(690, "PersonRoleIds");
            type.Add(550, "EquipmentConfigurationGroup");
            type.Add(51, "GuidanceAllocationIds");
            type.Add(48, "WorkItemIds");
            type.Add(56, "SummaryId");
            type.Add(49, "Notes");
            type.Add(55, "OperationData");
            type.Add(681, "Description");
        }

        private void AddNumericWorkingData(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(NumericWorkingData), _useDefaults);
            type.Add(489, "UnitOfMeasure");
            type.Add(490, "Values");
        }

        private void AddOperationData(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(OperationData), _useDefaults);
            type.Add(60, "Id");
            type.Add(63, "LoadId");
            type.Add(64, "OperationType");
            type.Add(65, "PrescriptionId");
            type.Add(66, "ProductId");
            type.Add(67, "VarietyLocatorId");
            type.Add(68, "WorkItemOperationId");
            type.Add(69, "MaxDepth");
            type.Add(70, "SpatialRecordCount");
            type.Add(551, "EquipmentConfigurationIds");
        }

        private void AddSectionSummary(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SectionSummary), _useDefaults);
            type.Add(79, "Id");
            type.Add(80, "SectionId");
            type.Add(81, "TotalDistanceTravelled");
            type.Add(82, "TotalElapsedTime");
        }

        private void AddSpatialRecord(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SpatialRecord), _useDefaults);
            type.Add(83, "Geometry");
            type.Add(84, "Timestamp");
            type.Add(85, "_meterValues");
            type.Add(86, "_appliedLatencyValues");
        }

        #endregion LoggedData

        #region Logistics

        private void AddCropZone(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CropZone), _useDefaults);
            type.Add(368, "Id");
            type.Add(823, "TimeScopes");
            type.Add(370, "Description");
            type.Add(371, "FieldId");
            type.Add(372, "CropId");
            type.Add(373, "Area");
            type.Add(374, "BoundingRegion");
            type.Add(375, "BoundarySource");
            type.Add(376, "Notes");
            type.Add(377, "GuidanceGroupIds");
            type.Add(378, "ContextItems");
        }

        private void AddBrand(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Brand), _useDefaults);
            type.Add(379, "Id");
            type.Add(380, "Description");
            type.Add(381, "ManufacturerId");
            type.Add(382, "ContextItems");
        }

        private void AddCompany(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Company), _useDefaults);
            type.Add(383, "Id");
            type.Add(384, "Name");
            type.Add(385, "ContactInfoId");
            type.Add(386, "ContextItems");
        }

        private void AddContact(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Contact), _useDefaults);
            type.Add(387, "Number");
            type.Add(388, "Type");
        }

        private void AddContactInfo(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ContactInfo), _useDefaults);
            type.Add(389, "Id");
            type.Add(390, "AddressLine1");
            type.Add(391, "AddressLine2");
            type.Add(392, "PoBoxNumber");
            type.Add(393, "PostalCode");
            type.Add(394, "City");
            type.Add(395, "StateOrProvince");
            type.Add(396, "Country");
            type.Add(397, "CountryCode");
            type.Add(398, "Contacts");
            type.Add(399, "Location");
            type.Add(400, "ContextItems");
        }

        private void AddFacility(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Facility), _useDefaults);
            type.Add(401, "Id");
            type.Add(402, "CompanyId");
            type.Add(403, "Description");
            type.Add(404, "ContactInfo");
            type.Add(405, "FacilityType");
            type.Add(406, "ContextItems");
        }

        private void AddFarm(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Farm), _useDefaults);
            type.Add(407, "Id");
            type.Add(408, "Description");
            type.Add(409, "GrowerId");
            type.Add(410, "ContactInfo");
            type.Add(824, "TimeScopes");
            type.Add(412, "ContextItems");
        }

        private void AddField(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Field), _useDefaults);
            type.Add(413, "Id");
            type.Add(414, "Description");
            type.Add(415, "FarmId");
            type.Add(416, "Area");
            type.Add(417, "ActiveBoundaryId");
            type.Add(418, "ContextItems");
            type.Add(419, "Slope");
            type.Add(420, "Aspect");
            type.Add(421, "SlopeLength");
            type.Add(422, "GuidanceGroupIds");
            type.Add(825, "TimeScopes");
        }

        private void AddGpsSource(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(GpsSource), _useDefaults);
            type.Add(426, "SourceType");
            type.Add(427, "EstimatedPrecision");
            type.Add(428, "HorizontalAccuracy");
            type.Add(429, "VerticalAccuracy");
            type.Add(430, "NumberOfSatellites");
            type.Add(431, "GpsUtcTime");
        }

        private void AddGrower(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Grower), _useDefaults);
            type.Add(432, "Id");
            type.Add(433, "Name");
            type.Add(434, "ContactInfo");
            type.Add(435, "ContextItems");
        }

        private void AddLocation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Location), _useDefaults);
            type.Add(436, "Position");
            type.Add(437, "ContextItems");
            type.Add(438, "GpsSource");
        }

        private void AddDestination(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Destination), _useDefaults);
            type.Add(439, "Id");
            type.Add(440, "Description");
            type.Add(441, "Location");
            type.Add(442, "FacilityId");
        }

        private void AddManufacturer(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Manufacturer), _useDefaults);
            type.Add(443, "Id");
            type.Add(444, "Description");
        }

        private void AddPermittedProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(PermittedProduct), _useDefaults);
            type.Add(445, "Id");
            type.Add(446, "TimeScopes");
            type.Add(447, "GrowerId");
            type.Add(448, "ProductId");
            type.Add(449, "ContextItems");
        }

        private void AddPerson(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Person), _useDefaults);
            type.Add(450, "Id");
            type.Add(451, "FirstName");
            type.Add(452, "MiddleName");
            type.Add(453, "LastName");
            type.Add(454, "CombinedName");
            type.Add(455, "ContactInfoId");
            type.Add(456, "ContextItems");
        }

        private void AddPersonRole(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(PersonRole), _useDefaults);
            type.Add(457, "Id");
            type.Add(458, "PersonId");
            type.Add(459, "Role");
            type.Add(460, "GrowerId");
            type.Add(461, "TimeScopes");
            type.Add(462, "CompanyId");
        }

        #endregion Logistics

        #region Notes

        private void AddNote(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Note), _useDefaults);
            type.Add(315, "Description");
            type.Add(316, "Value");
            type.Add(330, "TimeStamps");
            type.Add(318, "SpatialContext");
        }

        #endregion Notes

        #region Prescriptions

        private void AddRxProductLookup(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RxProductLookup), _useDefaults);
            model[typeof(RxProductLookup)].Add(712, "Id");
            model[typeof(RxProductLookup)].Add(713, "ProductId");
            model[typeof(RxProductLookup)].Add(714, "Representation");
            model[typeof(RxProductLookup)].Add(715, "UnitOfMeasure");
        }

        private void AddPrescription(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Prescription), _useDefaults);
            type.Add(716, "Id");
            type.Add(717, "Description");
            type.Add(718, "OperationType");
            type.Add(719, "FieldId");
            type.Add(720, "CropZoneId");
            type.Add(721, "RxProductLookups");
            type.Add(722, "ProductIds");
            type.Add(723, "ContextItems");

            type.AddSubType(724, typeof(ManualPrescription));
            type.AddSubType(730, typeof(SpatialPrescription));
        }

        private void AddManualPrescription(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ManualPrescription), _useDefaults);
            type.Add(725, "ProductUses");
            type.Add(726, "TotalArea");
            type.Add(727, "TankAmount");
            type.Add(728, "TotalTanks");
            type.Add(729, "ApplicationStrategy");
        }

        private void AddSpatialPrescription(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SpatialPrescription), _useDefaults);
            type.Add(731, "BoundingBox");
            type.Add(732, "OutOfFieldRate");
            type.Add(733, "LossOfGpsRate");

            type.AddSubType(734, typeof(RasterGridPrescription));
            type.AddSubType(746, typeof(VectorPrescription));
        }

        private void AddRasterGridPrescription(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RasterGridPrescription), _useDefaults);
            type.Add(735, "Origin");
            type.Add(736, "RowCount");
            type.Add(737, "ColumnCount");
            type.Add(738, "CellWidth");
            type.Add(739, "CellHeight");
            type.Add(740, "Rates");
        }

        private void AddRxRate(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RxRate), _useDefaults);
            type.Add(741, "Rate");
            type.Add(742, "RxProductLookupId");
        }

        private void AddRxRates(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RxRates), _useDefaults);
            type.Add(743, "RxRate");
        }

        private void AddRxShapeLookup(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RxShapeLookup), _useDefaults);
            type.Add(744, "Shape");
            type.Add(745, "Rates");
        }

        private void AddVectorPrescription(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(VectorPrescription), _useDefaults);
            type.Add(747, "RxShapeLookups");
        }

        #endregion Presecriptions

        #region Products

        private void AddIngredient(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Ingredient), _useDefaults);
            type.Add(748, "Id");
            type.Add(749, "Description");
            type.Add(750, "ContextItems");

            type.AddSubType(751, typeof(ActiveIngredient));
            type.AddSubType(763, typeof(CropNutritionIngredient));
        }

        private void AddAvailableProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(AvailableProduct), _useDefaults);
            type.Add(753, "Id");
            type.Add(754, "ProductId");
            type.Add(755, "GrowerId");
            type.Add(756, "ContextItems");
            type.Add(846, "TimeScopes");
        }

        private void AddProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Product), _useDefaults);
            type.Add(765, "Id");
            type.Add(766, "BrandId");
            type.Add(767, "Category");
            type.Add(768, "ContextItems");
            type.Add(769, "Density");
            type.Add(770, "Description");
            type.Add(771, "Form");
            type.Add(772, "HasCropProtection");
            type.Add(773, "HasCropNutrition");
            type.Add(774, "HasCropVariety");
            type.Add(775, "HasHarvestCommodity");
            type.Add(776, "ManufacturerId");
            type.Add(777, "ProductComponents");
            type.Add(778, "ProductType");
            type.Add(779, "Status");

            type.AddSubType(830, typeof(GenericProduct));
            type.AddSubType(828, typeof(HarvestedCommodityProduct));
            type.AddSubType(780, typeof(CropProtectionProduct));
            type.AddSubType(784, typeof(CropVarietyProduct));
            type.AddSubType(794, typeof(CropNutritionProduct));
            type.AddSubType(807, typeof(MixProduct));
        }

        private void AddHarvestedCommodityProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(HarvestedCommodityProduct), _useDefaults);
            type.Add(829, "CropId");
        }

        private void AddCrop(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Crop), _useDefaults);
            type.Add(757, "Id");
            type.Add(758, "Name");
            type.Add(759, "ParentId");
            type.Add(760, "ReferenceWeight");
            type.Add(761, "StandardPayableMoisture");
            type.Add(762, "ContextItems");
        }

        private void AddCropNutritionIngredient(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CropNutritionIngredient), _useDefaults);
            type.Add(764, "IngredientCode");
        }

        private void AddCropProtectionProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CropProtectionProduct), _useDefaults);
            type.Add(781, "Biological");
            type.Add(782, "Organophosphate");
            type.Add(783, "Carbamate");
        }

        private void AddCropVarietyProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CropVarietyProduct), _useDefaults);
            type.Add(785, "CropId");
            type.Add(786, "TraitIds");
            type.Add(787, "GeneticallyEnhanced");
        }

        private void AddDensityFactor(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(DensityFactor), _useDefaults);
            type.Add(788, "Id");
            type.Add(789, "ProductId");
            type.Add(790, "BatchNo");
            type.Add(791, "LotNo");
            type.Add(792, "Density");
            type.Add(793, "TimeScopeIds");
        }

        private void AddCropNutritionProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(CropNutritionProduct), _useDefaults);
            type.Add(795, "IsManure");
        }

        private void AddIngredientUse(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(IngredientUse), _useDefaults);
            type.Add(796, "Id");
            type.Add(797, "ProductId");
            type.Add(798, "IngredientId");
            type.Add(799, "Fraction");
            type.Add(800, "IsProduct");
        }

        private void AddProductComponent(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ProductComponent), _useDefaults);
            type.Add(803, "IngredientId");
            type.Add(804, "Quantity");
            type.Add(805, "IsProduct");
            type.Add(806, "IsCarrier");
        }

        private void AddMixProduct(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MixProduct), _useDefaults);
            type.Add(808, "TotalQuantity");
            type.Add(809, "IsTemporary");
            type.Add(810, "IsHotMix");
        }

        private void AddProductUse(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ProductUse), _useDefaults);
            type.Add(811, "ProductId");
            type.Add(812, "Rate");
            type.Add(813, "AppliedArea");
            type.Add(814, "ProductTotal");
        }

        private void AddTrait(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Trait), _useDefaults);
            type.Add(815, "Id");
            type.Add(816, "TraitCode");
            type.Add(817, "Description");
            type.Add(818, "ManufacturerId");
            type.Add(819, "CropIds");
        }

        #endregion Products

        #region ReferenceLayers

        private void AddReferenceLayer(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ReferenceLayer), _useDefaults);
            type.Add(333, "Id");
            type.Add(334, "Description");
            type.Add(335, "LayerType");
            type.Add(336, "TimeScopes");
            type.Add(337, "BoundingPolygon");
            type.Add(338, "ContextItems");
            type.Add(339, "FieldIds");
            type.Add(340, "CropZoneIds");

            type.AddSubType(341, typeof(RasterReferenceLayer));
            type.AddSubType(352, typeof(ShapeReferenceLayer));
        }

        private void AddRasterReferenceLayer(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RasterReferenceLayer), _useDefaults);
            type.Add(342, "Origin");
            type.Add(343, "RowCount");
            type.Add(344, "ColumnCount");
            type.Add(345, "CellWidth");
            type.Add(346, "CellHeight");
            type.Add(347, "EnumeratedRasterValues");
            type.Add(348, "StringRasterValues");
            type.Add(349, "NumericRasterValues");
        }

        private void AddShapeLookup(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ShapeLookup), _useDefaults);
           type.Add(350, "Shape");
           type.Add(351, "SpatialAttribute");
        }

        private void AddShapeReferenceLayer(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ShapeReferenceLayer), _useDefaults);            
            type.Add(353, "ShapeLookups");
        }

        private void AddSpatialAttribute(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SpatialAttribute), _useDefaults);
            type.Add(354, "Values");
        }

        private void AddRasterDataEnumerated(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RasterData<EnumeratedRepresentation, EnumerationMember>), _useDefaults);
            type.Add(463, "Representation");
        }

        private void AddRasterDataString(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RasterData<StringRepresentation, string>), _useDefaults);
            type.Add(464, "Representation");
        }

        private void AddRasterDataNumeric(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RasterData<NumericRepresentation, NumericValue>), _useDefaults);
            type.Add(465, "Representation");
        }

        private void AddSerializableRasterDataEnumeration(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SerializableRasterData<EnumerationMember>), _useDefaults);
            type.Add(467, "values");
            type.Add(470, "Representation");
        }

        private void AddSerializableRasterDataString(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SerializableRasterData<string>), _useDefaults);
            type.Add(466, "values");
            type.Add(469, "Representation");
        }

        private void AddSerializableRasterDataNumeric(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SerializableRasterData<NumericValue>), _useDefaults);
            type.Add(468, "values");
            type.Add(471, "Representation");
        }

        private void AddSerializableReferenceLayer(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(SerializableReferenceLayer), _useDefaults);
            type.Add(472, "ReferenceLayer");
            type.Add(473, "StringValues");
            type.Add(474, "EnumerationMemberValues");
            type.Add(475, "NumericValueValues");
        }

        #endregion ReferenceLayers

        #region Representations

        private void AddEnumerationMember(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EnumerationMember), _useDefaults);
            type.Add(109, "Code");
            type.Add(110, "Value");
        }

        private void AddRepresentation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(ApplicationDataModel.Representations.Representation), _useDefaults);
            type.Add(111, "Id");
            type.Add(112, "CodeSource");
            type.Add(113, "Code");
            type.Add(114, "Description");
            type.Add(115, "LongDescription");

            type.AddSubType(116, typeof(EnumeratedRepresentation));
            type.AddSubType(129, typeof(NumericRepresentation));
            type.AddSubType(138, typeof(StringRepresentation));
        }

        private void AddEnumeratedRepresentation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EnumeratedRepresentation), _useDefaults);
            type.Add(117, "EnumeratedMembers");
            type.Add(118, "RepresentationGroupId");
        }

        private void AddEnumeratedRepresentationGroup(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EnumeratedRepresentationGroup), _useDefaults);
            type.Add(119, "Id");
            type.Add(120, "Description");
        }

        private void AddRepresentationValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(RepresentationValue), _useDefaults);
            type.Add(121, "Code");
            type.Add(122, "Designator");
            type.Add(123, "Color");

            type.AddSubType(124, typeof(EnumeratedValue));
            type.AddSubType(134, typeof(NumericRepresentationValue));
            type.AddSubType(141, typeof(StringValue));            
        }

        private void AddEnumeratedValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(EnumeratedValue), _useDefaults);
            type.Add(125, "Representation");
            type.Add(126, "Value");
        }

        private void AddNumericValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(NumericValue), _useDefaults);
            type.Add(127, "Value");
            type.Add(128, "UnitOfMeasure");
        }

        private void AddNumericRepresentation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(NumericRepresentation), _useDefaults);
            type.Add(130, "DecimalDigits");
            type.Add(131, "MinValue");
            type.Add(132, "MaxValue");
            type.Add(133, "Dimension");
        }

        private void AddNumericRepresentationValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(NumericRepresentationValue), _useDefaults);
            type.Add(135, "Representation");
            type.Add(136, "Value");
            type.Add(137, "UserProvidedUnitOfMeasure");
        }

        private void AddStringRepresentation(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(StringRepresentation), _useDefaults);
            type.Add(139, "MinCharacters");
            type.Add(140, "MaxCharacters");
        }

        private void AddStringValue(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(StringValue), _useDefaults);
            type.Add(142, "Representation");
            type.Add(143, "Value");
        }

        #endregion Representations

        #region Shapes

        private void AddBoundingBox(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(BoundingBox), _useDefaults);
            type.Add(324, "MinY");
            type.Add(325, "MinX");
            type.Add(326, "MaxY");
            type.Add(327, "MaxX");
        }

        private void AddShape(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Shape), _useDefaults);
            type.Add(148, "Id");
            type.Add(149, "Type");

            type.AddSubType(150, typeof(LinearRing));
            type.AddSubType(152, typeof(LineString));
            type.AddSubType(154, typeof(MultiLineString));
            type.AddSubType(156, typeof(MultiPoint));
            type.AddSubType(158, typeof(MultiPolygon));
            type.AddSubType(160, typeof(Point));
            type.AddSubType(164, typeof(Polygon));
        }

        private void AddLinearRing(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(LinearRing), _useDefaults);
            type.Add(151, "Points");
        }

        private void AddLineString(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(LineString), _useDefaults);
            type.Add(153, "Points");
        }

        private void AddMultiLineString(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MultiLineString), _useDefaults);
            type.Add(155, "LineStrings");
        }

        private void AddMultiPoint(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MultiPoint), _useDefaults);
            type.Add(157, "Points");
        }

        private void AddMultiPolygon(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(MultiPolygon), _useDefaults);
            type.Add(159, "Polygons");
        }

        private void AddPoint(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Point), _useDefaults);
            type.Add(161, "X");
            type.Add(162, "Y");
            type.Add(163, "Z");
        }

        private void AddPolygon(RuntimeTypeModel model)
        {
            var type = model.Add(typeof(Polygon), _useDefaults);
            type.Add(165, "ExteriorRing");
            type.Add(166, "InteriorRings");
        }

        #endregion Shapes
    }
}
