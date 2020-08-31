using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Sample
{
    [ExcludeFromCodeCoverage]
    public class DatabaseMetadataProvider : IDatabaseMetadataProvider
    {
        public IndexDetails GetIndexDetails(string indexName)
        {
            IndexDetails indexDetails = null;

            IndexDetailsByName.TryGetValue(indexName, out indexDetails);

            return indexDetails;
        }

        private static readonly Dictionary<string, IndexDetails> IndexDetailsByName = new Dictionary<string, IndexDetails>(StringComparer.InvariantCultureIgnoreCase) {
            { "ArtMediumDescriptor_PK", new IndexDetails { IndexName = "ArtMediumDescriptor_PK", TableName = "ArtMediumDescriptor", ColumnNames = new List<string> { "ArtMediumDescriptorId" } } },
            { "Bus_PK", new IndexDetails { IndexName = "Bus_PK", TableName = "Bus", ColumnNames = new List<string> { "BusId" } } },
            { "UX_Bus_Id", new IndexDetails { IndexName = "UX_Bus_Id", TableName = "Bus", ColumnNames = new List<string> { "Id" } } },
            { "BusRoute_PK", new IndexDetails { IndexName = "BusRoute_PK", TableName = "BusRoute", ColumnNames = new List<string> { "BusId", "BusRouteNumber" } } },
            { "FK_BusRoute_DisabilityDescriptor", new IndexDetails { IndexName = "FK_BusRoute_DisabilityDescriptor", TableName = "BusRoute", ColumnNames = new List<string> { "DisabilityDescriptorId" } } },
            { "FK_BusRoute_StaffEducationOrganizationAssignmentAssociation", new IndexDetails { IndexName = "FK_BusRoute_StaffEducationOrganizationAssignmentAssociation", TableName = "BusRoute", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "StaffClassificationDescriptorId", "StaffUSI" } } },
            { "UX_BusRoute_Id", new IndexDetails { IndexName = "UX_BusRoute_Id", TableName = "BusRoute", ColumnNames = new List<string> { "Id" } } },
            { "BusRouteBusYear_PK", new IndexDetails { IndexName = "BusRouteBusYear_PK", TableName = "BusRouteBusYear", ColumnNames = new List<string> { "BusId", "BusRouteNumber", "BusYear" } } },
            { "FK_BusRouteBusYear_BusRoute", new IndexDetails { IndexName = "FK_BusRouteBusYear_BusRoute", TableName = "BusRouteBusYear", ColumnNames = new List<string> { "BusId", "BusRouteNumber" } } },
            { "BusRouteProgram_PK", new IndexDetails { IndexName = "BusRouteProgram_PK", TableName = "BusRouteProgram", ColumnNames = new List<string> { "BusId", "BusRouteNumber", "EducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId" } } },
            { "FK_BusRouteProgram_BusRoute", new IndexDetails { IndexName = "FK_BusRouteProgram_BusRoute", TableName = "BusRouteProgram", ColumnNames = new List<string> { "BusId", "BusRouteNumber" } } },
            { "FK_BusRouteProgram_Program", new IndexDetails { IndexName = "FK_BusRouteProgram_Program", TableName = "BusRouteProgram", ColumnNames = new List<string> { "EducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId" } } },
            { "BusRouteServiceAreaPostalCode_PK", new IndexDetails { IndexName = "BusRouteServiceAreaPostalCode_PK", TableName = "BusRouteServiceAreaPostalCode", ColumnNames = new List<string> { "BusId", "BusRouteNumber", "ServiceAreaPostalCode" } } },
            { "FK_BusRouteServiceAreaPostalCode_BusRoute", new IndexDetails { IndexName = "FK_BusRouteServiceAreaPostalCode_BusRoute", TableName = "BusRouteServiceAreaPostalCode", ColumnNames = new List<string> { "BusId", "BusRouteNumber" } } },
            { "BusRouteStartTime_PK", new IndexDetails { IndexName = "BusRouteStartTime_PK", TableName = "BusRouteStartTime", ColumnNames = new List<string> { "BusId", "BusRouteNumber", "StartTime" } } },
            { "FK_BusRouteStartTime_BusRoute", new IndexDetails { IndexName = "FK_BusRouteStartTime_BusRoute", TableName = "BusRouteStartTime", ColumnNames = new List<string> { "BusId", "BusRouteNumber" } } },
            { "BusRouteTelephone_PK", new IndexDetails { IndexName = "BusRouteTelephone_PK", TableName = "BusRouteTelephone", ColumnNames = new List<string> { "BusId", "BusRouteNumber", "TelephoneNumber", "TelephoneNumberTypeDescriptorId" } } },
            { "FK_BusRouteTelephone_BusRoute", new IndexDetails { IndexName = "FK_BusRouteTelephone_BusRoute", TableName = "BusRouteTelephone", ColumnNames = new List<string> { "BusId", "BusRouteNumber" } } },
            { "FK_BusRouteTelephone_TelephoneNumberTypeDescriptor", new IndexDetails { IndexName = "FK_BusRouteTelephone_TelephoneNumberTypeDescriptor", TableName = "BusRouteTelephone", ColumnNames = new List<string> { "TelephoneNumberTypeDescriptorId" } } },
            { "FavoriteBookCategoryDescriptor_PK", new IndexDetails { IndexName = "FavoriteBookCategoryDescriptor_PK", TableName = "FavoriteBookCategoryDescriptor", ColumnNames = new List<string> { "FavoriteBookCategoryDescriptorId" } } },
            { "MembershipTypeDescriptor_PK", new IndexDetails { IndexName = "MembershipTypeDescriptor_PK", TableName = "MembershipTypeDescriptor", ColumnNames = new List<string> { "MembershipTypeDescriptorId" } } },
            { "ParentAddressExtension_PK", new IndexDetails { IndexName = "ParentAddressExtension_PK", TableName = "ParentAddressExtension", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "ParentUSI", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName" } } },
            { "FK_ParentAddressSchoolDistrict_ParentAddress", new IndexDetails { IndexName = "FK_ParentAddressSchoolDistrict_ParentAddress", TableName = "ParentAddressSchoolDistrict", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "ParentUSI", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName" } } },
            { "ParentAddressSchoolDistrict_PK", new IndexDetails { IndexName = "ParentAddressSchoolDistrict_PK", TableName = "ParentAddressSchoolDistrict", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "ParentUSI", "PostalCode", "SchoolDistrict", "StateAbbreviationDescriptorId", "StreetNumberName" } } },
            { "FK_ParentAddressTerm_ParentAddress", new IndexDetails { IndexName = "FK_ParentAddressTerm_ParentAddress", TableName = "ParentAddressTerm", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "ParentUSI", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName" } } },
            { "FK_ParentAddressTerm_TermDescriptor", new IndexDetails { IndexName = "FK_ParentAddressTerm_TermDescriptor", TableName = "ParentAddressTerm", ColumnNames = new List<string> { "TermDescriptorId" } } },
            { "ParentAddressTerm_PK", new IndexDetails { IndexName = "ParentAddressTerm_PK", TableName = "ParentAddressTerm", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "ParentUSI", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName", "TermDescriptorId" } } },
            { "FK_ParentAuthor_Parent", new IndexDetails { IndexName = "FK_ParentAuthor_Parent", TableName = "ParentAuthor", ColumnNames = new List<string> { "ParentUSI" } } },
            { "ParentAuthor_PK", new IndexDetails { IndexName = "ParentAuthor_PK", TableName = "ParentAuthor", ColumnNames = new List<string> { "Author", "ParentUSI" } } },
            { "FK_ParentCeilingHeight_Parent", new IndexDetails { IndexName = "FK_ParentCeilingHeight_Parent", TableName = "ParentCeilingHeight", ColumnNames = new List<string> { "ParentUSI" } } },
            { "ParentCeilingHeight_PK", new IndexDetails { IndexName = "ParentCeilingHeight_PK", TableName = "ParentCeilingHeight", ColumnNames = new List<string> { "CeilingHeight", "ParentUSI" } } },
            { "FK_ParentCTEProgram_CareerPathwayDescriptor", new IndexDetails { IndexName = "FK_ParentCTEProgram_CareerPathwayDescriptor", TableName = "ParentCTEProgram", ColumnNames = new List<string> { "CareerPathwayDescriptorId" } } },
            { "ParentCTEProgram_PK", new IndexDetails { IndexName = "ParentCTEProgram_PK", TableName = "ParentCTEProgram", ColumnNames = new List<string> { "ParentUSI" } } },
            { "FK_ParentEducationContent_EducationContent", new IndexDetails { IndexName = "FK_ParentEducationContent_EducationContent", TableName = "ParentEducationContent", ColumnNames = new List<string> { "ContentIdentifier" } } },
            { "FK_ParentEducationContent_Parent", new IndexDetails { IndexName = "FK_ParentEducationContent_Parent", TableName = "ParentEducationContent", ColumnNames = new List<string> { "ParentUSI" } } },
            { "ParentEducationContent_PK", new IndexDetails { IndexName = "ParentEducationContent_PK", TableName = "ParentEducationContent", ColumnNames = new List<string> { "ContentIdentifier", "ParentUSI" } } },
            { "FK_ParentExtension_CredentialFieldDescriptor", new IndexDetails { IndexName = "FK_ParentExtension_CredentialFieldDescriptor", TableName = "ParentExtension", ColumnNames = new List<string> { "CredentialFieldDescriptorId" } } },
            { "ParentExtension_PK", new IndexDetails { IndexName = "ParentExtension_PK", TableName = "ParentExtension", ColumnNames = new List<string> { "ParentUSI" } } },
            { "FK_ParentFavoriteBookTitle_Parent", new IndexDetails { IndexName = "FK_ParentFavoriteBookTitle_Parent", TableName = "ParentFavoriteBookTitle", ColumnNames = new List<string> { "ParentUSI" } } },
            { "ParentFavoriteBookTitle_PK", new IndexDetails { IndexName = "ParentFavoriteBookTitle_PK", TableName = "ParentFavoriteBookTitle", ColumnNames = new List<string> { "FavoriteBookTitle", "ParentUSI" } } },
            { "FK_ParentStudentProgramAssociation_Parent", new IndexDetails { IndexName = "FK_ParentStudentProgramAssociation_Parent", TableName = "ParentStudentProgramAssociation", ColumnNames = new List<string> { "ParentUSI" } } },
            { "FK_ParentStudentProgramAssociation_StudentProgramAssociation", new IndexDetails { IndexName = "FK_ParentStudentProgramAssociation_StudentProgramAssociation", TableName = "ParentStudentProgramAssociation", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "ParentStudentProgramAssociation_PK", new IndexDetails { IndexName = "ParentStudentProgramAssociation_PK", TableName = "ParentStudentProgramAssociation", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ParentUSI", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "ParentTeacherConference_PK", new IndexDetails { IndexName = "ParentTeacherConference_PK", TableName = "ParentTeacherConference", ColumnNames = new List<string> { "ParentUSI" } } },
            { "FK_SchoolCTEProgram_CareerPathwayDescriptor", new IndexDetails { IndexName = "FK_SchoolCTEProgram_CareerPathwayDescriptor", TableName = "SchoolCTEProgram", ColumnNames = new List<string> { "CareerPathwayDescriptorId" } } },
            { "SchoolCTEProgram_PK", new IndexDetails { IndexName = "SchoolCTEProgram_PK", TableName = "SchoolCTEProgram", ColumnNames = new List<string> { "SchoolId" } } },
            { "FK_SchoolDirectlyOwnedBus_Bus", new IndexDetails { IndexName = "FK_SchoolDirectlyOwnedBus_Bus", TableName = "SchoolDirectlyOwnedBus", ColumnNames = new List<string> { "DirectlyOwnedBusId" } } },
            { "FK_SchoolDirectlyOwnedBus_School", new IndexDetails { IndexName = "FK_SchoolDirectlyOwnedBus_School", TableName = "SchoolDirectlyOwnedBus", ColumnNames = new List<string> { "SchoolId" } } },
            { "SchoolDirectlyOwnedBus_PK", new IndexDetails { IndexName = "SchoolDirectlyOwnedBus_PK", TableName = "SchoolDirectlyOwnedBus", ColumnNames = new List<string> { "DirectlyOwnedBusId", "SchoolId" } } },
            { "SchoolExtension_PK", new IndexDetails { IndexName = "SchoolExtension_PK", TableName = "SchoolExtension", ColumnNames = new List<string> { "SchoolId" } } },
            { "StaffExtension_PK", new IndexDetails { IndexName = "StaffExtension_PK", TableName = "StaffExtension", ColumnNames = new List<string> { "StaffUSI" } } },
            { "FK_StaffPet_Staff", new IndexDetails { IndexName = "FK_StaffPet_Staff", TableName = "StaffPet", ColumnNames = new List<string> { "StaffUSI" } } },
            { "StaffPet_PK", new IndexDetails { IndexName = "StaffPet_PK", TableName = "StaffPet", ColumnNames = new List<string> { "PetName", "StaffUSI" } } },
            { "StaffPetPreference_PK", new IndexDetails { IndexName = "StaffPetPreference_PK", TableName = "StaffPetPreference", ColumnNames = new List<string> { "StaffUSI" } } },
            { "FK_StudentAquaticPet_Student", new IndexDetails { IndexName = "FK_StudentAquaticPet_Student", TableName = "StudentAquaticPet", ColumnNames = new List<string> { "StudentUSI" } } },
            { "StudentAquaticPet_PK", new IndexDetails { IndexName = "StudentAquaticPet_PK", TableName = "StudentAquaticPet", ColumnNames = new List<string> { "MimimumTankVolume", "PetName", "StudentUSI" } } },
            { "StudentArtProgramAssociation_PK", new IndexDetails { IndexName = "StudentArtProgramAssociation_PK", TableName = "StudentArtProgramAssociation", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "FK_StudentArtProgramAssociationArtMedium_ArtMediumDescriptor", new IndexDetails { IndexName = "FK_StudentArtProgramAssociationArtMedium_ArtMediumDescriptor", TableName = "StudentArtProgramAssociationArtMedium", ColumnNames = new List<string> { "ArtMediumDescriptorId" } } },
            { "FK_StudentArtProgramAssociationArtMedium_StudentArtProgramAssociation", new IndexDetails { IndexName = "FK_StudentArtProgramAssociationArtMedium_StudentArtProgramAssociation", TableName = "StudentArtProgramAssociationArtMedium", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "StudentArtProgramAssociationArtMedium_PK", new IndexDetails { IndexName = "StudentArtProgramAssociationArtMedium_PK", TableName = "StudentArtProgramAssociationArtMedium", ColumnNames = new List<string> { "ArtMediumDescriptorId", "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "FK_StudentArtProgramAssociationPortfolioYears_StudentArtProgramAssociation", new IndexDetails { IndexName = "FK_StudentArtProgramAssociationPortfolioYears_StudentArtProgramAssociation", TableName = "StudentArtProgramAssociationPortfolioYears", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "StudentArtProgramAssociationPortfolioYears_PK", new IndexDetails { IndexName = "StudentArtProgramAssociationPortfolioYears_PK", TableName = "StudentArtProgramAssociationPortfolioYears", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "PortfolioYears", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "FK_StudentArtProgramAssociationService_ServiceDescriptor", new IndexDetails { IndexName = "FK_StudentArtProgramAssociationService_ServiceDescriptor", TableName = "StudentArtProgramAssociationService", ColumnNames = new List<string> { "ServiceDescriptorId" } } },
            { "FK_StudentArtProgramAssociationService_StudentArtProgramAssociation", new IndexDetails { IndexName = "FK_StudentArtProgramAssociationService_StudentArtProgramAssociation", TableName = "StudentArtProgramAssociationService", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "StudentArtProgramAssociationService_PK", new IndexDetails { IndexName = "StudentArtProgramAssociationService_PK", TableName = "StudentArtProgramAssociationService", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "ServiceDescriptorId", "StudentUSI" } } },
            { "FK_StudentArtProgramAssociationStyle_StudentArtProgramAssociation", new IndexDetails { IndexName = "FK_StudentArtProgramAssociationStyle_StudentArtProgramAssociation", TableName = "StudentArtProgramAssociationStyle", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "StudentArtProgramAssociationStyle_PK", new IndexDetails { IndexName = "StudentArtProgramAssociationStyle_PK", TableName = "StudentArtProgramAssociationStyle", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI", "Style" } } },
            { "StudentCTEProgramAssociationExtension_PK", new IndexDetails { IndexName = "StudentCTEProgramAssociationExtension_PK", TableName = "StudentCTEProgramAssociationExtension", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "StudentEducationOrganizationAssociationAddressExtension_PK", new IndexDetails { IndexName = "StudentEducationOrganizationAssociationAddressExtension_PK", TableName = "StudentEducationOrganizationAssociationAddressExtension", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "EducationOrganizationId", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName", "StudentUSI" } } },
            { "FK_StudentEducationOrganizationAssociationAddressSchoolDistrict_StudentEducationOrganizationAssociationAddress", new IndexDetails { IndexName = "FK_StudentEducationOrganizationAssociationAddressSchoolDistrict_StudentEducationOrganizationAssociationAddress", TableName = "StudentEducationOrganizationAssociationAddressSchoolDistrict", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "EducationOrganizationId", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName", "StudentUSI" } } },
            { "StudentEducationOrganizationAssociationAddressSchoolDistrict_PK", new IndexDetails { IndexName = "StudentEducationOrganizationAssociationAddressSchoolDistrict_PK", TableName = "StudentEducationOrganizationAssociationAddressSchoolDistrict", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "EducationOrganizationId", "PostalCode", "SchoolDistrict", "StateAbbreviationDescriptorId", "StreetNumberName", "StudentUSI" } } },
            { "FK_StudentEducationOrganizationAssociationAddressTerm_StudentEducationOrganizationAssociationAddress", new IndexDetails { IndexName = "FK_StudentEducationOrganizationAssociationAddressTerm_StudentEducationOrganizationAssociationAddress", TableName = "StudentEducationOrganizationAssociationAddressTerm", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "EducationOrganizationId", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName", "StudentUSI" } } },
            { "FK_StudentEducationOrganizationAssociationAddressTerm_TermDescriptor", new IndexDetails { IndexName = "FK_StudentEducationOrganizationAssociationAddressTerm_TermDescriptor", TableName = "StudentEducationOrganizationAssociationAddressTerm", ColumnNames = new List<string> { "TermDescriptorId" } } },
            { "StudentEducationOrganizationAssociationAddressTerm_PK", new IndexDetails { IndexName = "StudentEducationOrganizationAssociationAddressTerm_PK", TableName = "StudentEducationOrganizationAssociationAddressTerm", ColumnNames = new List<string> { "AddressTypeDescriptorId", "City", "EducationOrganizationId", "PostalCode", "StateAbbreviationDescriptorId", "StreetNumberName", "StudentUSI", "TermDescriptorId" } } },
            { "FK_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed_StudentEducationOrganizationAssociationStudentCharact", new IndexDetails { IndexName = "FK_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed_StudentEducationOrganizationAssociationStudentCharact", TableName = "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed", ColumnNames = new List<string> { "EducationOrganizationId", "StudentCharacteristicDescriptorId", "StudentUSI" } } },
            { "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed_PK", new IndexDetails { IndexName = "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed_PK", TableName = "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "StudentCharacteristicDescriptorId", "StudentUSI" } } },
            { "FK_StudentFavoriteBook_FavoriteBookCategoryDescriptor", new IndexDetails { IndexName = "FK_StudentFavoriteBook_FavoriteBookCategoryDescriptor", TableName = "StudentFavoriteBook", ColumnNames = new List<string> { "FavoriteBookCategoryDescriptorId" } } },
            { "FK_StudentFavoriteBook_Student", new IndexDetails { IndexName = "FK_StudentFavoriteBook_Student", TableName = "StudentFavoriteBook", ColumnNames = new List<string> { "StudentUSI" } } },
            { "StudentFavoriteBook_PK", new IndexDetails { IndexName = "StudentFavoriteBook_PK", TableName = "StudentFavoriteBook", ColumnNames = new List<string> { "FavoriteBookCategoryDescriptorId", "StudentUSI" } } },
            { "FK_StudentFavoriteBookArtMedium_ArtMediumDescriptor", new IndexDetails { IndexName = "FK_StudentFavoriteBookArtMedium_ArtMediumDescriptor", TableName = "StudentFavoriteBookArtMedium", ColumnNames = new List<string> { "ArtMediumDescriptorId" } } },
            { "FK_StudentFavoriteBookArtMedium_StudentFavoriteBook", new IndexDetails { IndexName = "FK_StudentFavoriteBookArtMedium_StudentFavoriteBook", TableName = "StudentFavoriteBookArtMedium", ColumnNames = new List<string> { "FavoriteBookCategoryDescriptorId", "StudentUSI" } } },
            { "StudentFavoriteBookArtMedium_PK", new IndexDetails { IndexName = "StudentFavoriteBookArtMedium_PK", TableName = "StudentFavoriteBookArtMedium", ColumnNames = new List<string> { "ArtMediumDescriptorId", "FavoriteBookCategoryDescriptorId", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociation_GraduationPlan", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociation_GraduationPlan", TableName = "StudentGraduationPlanAssociation", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear" } } },
            { "FK_StudentGraduationPlanAssociation_Staff", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociation_Staff", TableName = "StudentGraduationPlanAssociation", ColumnNames = new List<string> { "StaffUSI" } } },
            { "FK_StudentGraduationPlanAssociation_Student", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociation_Student", TableName = "StudentGraduationPlanAssociation", ColumnNames = new List<string> { "StudentUSI" } } },
            { "StudentGraduationPlanAssociation_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociation_PK", TableName = "StudentGraduationPlanAssociation", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "UX_StudentGraduationPlanAssociation_Id", new IndexDetails { IndexName = "UX_StudentGraduationPlanAssociation_Id", TableName = "StudentGraduationPlanAssociation", ColumnNames = new List<string> { "Id" } } },
            { "FK_StudentGraduationPlanAssociationAcademicSubject_AcademicSubjectDescriptor", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationAcademicSubject_AcademicSubjectDescriptor", TableName = "StudentGraduationPlanAssociationAcademicSubject", ColumnNames = new List<string> { "AcademicSubjectDescriptorId" } } },
            { "FK_StudentGraduationPlanAssociationAcademicSubject_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationAcademicSubject_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationAcademicSubject", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationAcademicSubject_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationAcademicSubject_PK", TableName = "StudentGraduationPlanAssociationAcademicSubject", ColumnNames = new List<string> { "AcademicSubjectDescriptorId", "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationCareerPathwayCode_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationCareerPathwayCode_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationCareerPathwayCode", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationCareerPathwayCode_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationCareerPathwayCode_PK", TableName = "StudentGraduationPlanAssociationCareerPathwayCode", ColumnNames = new List<string> { "CareerPathwayCode", "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationCTEProgram_CareerPathwayDescriptor", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationCTEProgram_CareerPathwayDescriptor", TableName = "StudentGraduationPlanAssociationCTEProgram", ColumnNames = new List<string> { "CareerPathwayDescriptorId" } } },
            { "StudentGraduationPlanAssociationCTEProgram_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationCTEProgram_PK", TableName = "StudentGraduationPlanAssociationCTEProgram", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationDescription_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationDescription_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationDescription", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationDescription_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationDescription_PK", TableName = "StudentGraduationPlanAssociationDescription", ColumnNames = new List<string> { "Description", "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationDesignatedBy_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationDesignatedBy_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationDesignatedBy", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationDesignatedBy_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationDesignatedBy_PK", TableName = "StudentGraduationPlanAssociationDesignatedBy", ColumnNames = new List<string> { "DesignatedBy", "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationIndustryCredential_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationIndustryCredential_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationIndustryCredential", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationIndustryCredential_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationIndustryCredential_PK", TableName = "StudentGraduationPlanAssociationIndustryCredential", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "IndustryCredential", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationStudentParentAssociation", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentParentAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentParentAssociation", TableName = "StudentGraduationPlanAssociationStudentParentAssociation", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationStudentParentAssociation_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationStudentParentAssociation_PK", TableName = "StudentGraduationPlanAssociationStudentParentAssociation", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "ParentUSI", "StudentUSI" } } },
            { "FK_StudentGraduationPlanAssociationYearsAttended_StudentGraduationPlanAssociation", new IndexDetails { IndexName = "FK_StudentGraduationPlanAssociationYearsAttended_StudentGraduationPlanAssociation", TableName = "StudentGraduationPlanAssociationYearsAttended", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI" } } },
            { "StudentGraduationPlanAssociationYearsAttended_PK", new IndexDetails { IndexName = "StudentGraduationPlanAssociationYearsAttended_PK", TableName = "StudentGraduationPlanAssociationYearsAttended", ColumnNames = new List<string> { "EducationOrganizationId", "GraduationPlanTypeDescriptorId", "GraduationSchoolYear", "StudentUSI", "YearsAttended" } } },
            { "FK_StudentParentAssociationDiscipline_DisciplineDescriptor", new IndexDetails { IndexName = "FK_StudentParentAssociationDiscipline_DisciplineDescriptor", TableName = "StudentParentAssociationDiscipline", ColumnNames = new List<string> { "DisciplineDescriptorId" } } },
            { "FK_StudentParentAssociationDiscipline_StudentParentAssociation", new IndexDetails { IndexName = "FK_StudentParentAssociationDiscipline_StudentParentAssociation", TableName = "StudentParentAssociationDiscipline", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "StudentParentAssociationDiscipline_PK", new IndexDetails { IndexName = "StudentParentAssociationDiscipline_PK", TableName = "StudentParentAssociationDiscipline", ColumnNames = new List<string> { "DisciplineDescriptorId", "ParentUSI", "StudentUSI" } } },
            { "FK_StudentParentAssociationExtension_InterventionStudy", new IndexDetails { IndexName = "FK_StudentParentAssociationExtension_InterventionStudy", TableName = "StudentParentAssociationExtension", ColumnNames = new List<string> { "EducationOrganizationId", "InterventionStudyIdentificationCode" } } },
            { "StudentParentAssociationExtension_PK", new IndexDetails { IndexName = "StudentParentAssociationExtension_PK", TableName = "StudentParentAssociationExtension", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "FK_StudentParentAssociationFavoriteBookTitle_StudentParentAssociation", new IndexDetails { IndexName = "FK_StudentParentAssociationFavoriteBookTitle_StudentParentAssociation", TableName = "StudentParentAssociationFavoriteBookTitle", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "StudentParentAssociationFavoriteBookTitle_PK", new IndexDetails { IndexName = "StudentParentAssociationFavoriteBookTitle_PK", TableName = "StudentParentAssociationFavoriteBookTitle", ColumnNames = new List<string> { "FavoriteBookTitle", "ParentUSI", "StudentUSI" } } },
            { "FK_StudentParentAssociationHoursPerWeek_StudentParentAssociation", new IndexDetails { IndexName = "FK_StudentParentAssociationHoursPerWeek_StudentParentAssociation", TableName = "StudentParentAssociationHoursPerWeek", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "StudentParentAssociationHoursPerWeek_PK", new IndexDetails { IndexName = "StudentParentAssociationHoursPerWeek_PK", TableName = "StudentParentAssociationHoursPerWeek", ColumnNames = new List<string> { "HoursPerWeek", "ParentUSI", "StudentUSI" } } },
            { "FK_StudentParentAssociationPagesRead_StudentParentAssociation", new IndexDetails { IndexName = "FK_StudentParentAssociationPagesRead_StudentParentAssociation", TableName = "StudentParentAssociationPagesRead", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "StudentParentAssociationPagesRead_PK", new IndexDetails { IndexName = "StudentParentAssociationPagesRead_PK", TableName = "StudentParentAssociationPagesRead", ColumnNames = new List<string> { "PagesRead", "ParentUSI", "StudentUSI" } } },
            { "FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StaffEducationOrganizationEmploymentAssociation", new IndexDetails { IndexName = "FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StaffEducationOrganizationEmploymentAssociation", TableName = "StudentParentAssociationStaffEducationOrganizationEmploymentAssociation", ColumnNames = new List<string> { "EducationOrganizationId", "EmploymentStatusDescriptorId", "HireDate", "StaffUSI" } } },
            { "FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StudentParentAssociation", new IndexDetails { IndexName = "FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StudentParentAssociation", TableName = "StudentParentAssociationStaffEducationOrganizationEmploymentAssociation", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_PK", new IndexDetails { IndexName = "StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_PK", TableName = "StudentParentAssociationStaffEducationOrganizationEmploymentAssociation", ColumnNames = new List<string> { "EducationOrganizationId", "EmploymentStatusDescriptorId", "HireDate", "ParentUSI", "StaffUSI", "StudentUSI" } } },
            { "FK_StudentParentAssociationTelephone_TelephoneNumberTypeDescriptor", new IndexDetails { IndexName = "FK_StudentParentAssociationTelephone_TelephoneNumberTypeDescriptor", TableName = "StudentParentAssociationTelephone", ColumnNames = new List<string> { "TelephoneNumberTypeDescriptorId" } } },
            { "StudentParentAssociationTelephone_PK", new IndexDetails { IndexName = "StudentParentAssociationTelephone_PK", TableName = "StudentParentAssociationTelephone", ColumnNames = new List<string> { "ParentUSI", "StudentUSI" } } },
            { "FK_StudentPet_Student", new IndexDetails { IndexName = "FK_StudentPet_Student", TableName = "StudentPet", ColumnNames = new List<string> { "StudentUSI" } } },
            { "StudentPet_PK", new IndexDetails { IndexName = "StudentPet_PK", TableName = "StudentPet", ColumnNames = new List<string> { "PetName", "StudentUSI" } } },
            { "StudentPetPreference_PK", new IndexDetails { IndexName = "StudentPetPreference_PK", TableName = "StudentPetPreference", ColumnNames = new List<string> { "StudentUSI" } } },
            { "FK_StudentSchoolAssociationExtension_MembershipTypeDescriptor", new IndexDetails { IndexName = "FK_StudentSchoolAssociationExtension_MembershipTypeDescriptor", TableName = "StudentSchoolAssociationExtension", ColumnNames = new List<string> { "MembershipTypeDescriptorId" } } },
            { "StudentSchoolAssociationExtension_PK", new IndexDetails { IndexName = "StudentSchoolAssociationExtension_PK", TableName = "StudentSchoolAssociationExtension", ColumnNames = new List<string> { "EntryDate", "SchoolId", "StudentUSI" } } },
        };
    }
}
