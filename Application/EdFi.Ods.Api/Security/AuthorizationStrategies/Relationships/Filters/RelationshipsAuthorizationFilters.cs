// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Filtering;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class RelationshipsAuthorizationFilters
    {
        private static readonly Lazy<FilterApplicationDetails> _schoolIdToSchoolId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("SchoolId"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToLocalEducationAgencyId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("LocalEducationAgencyId"));

        private static readonly Lazy<FilterApplicationDetails> _communityProviderIdToCommunityProviderId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("CommunityProviderId"));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToCommunityOrganizationId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("CommunityOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _postSecondaryInstitutionIdToPostSecondaryInstitutionId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("PostSecondaryInstitutionId"));

        private static readonly Lazy<FilterApplicationDetails> _stateEducationAgencyIdToStateEducationAgencyId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("StateEducationAgencyId"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToEducationServiceCenterId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("EducationServiceCenterId"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationServiceCenterIdToStudentUSI",
                        @"StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI
                            FROM auth.EducationOrganizationIdToStudentUSI {newAlias1}
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI
                            FROM " + "auth_EducationOrganizationIdToStudentUSI".GetFullNameForView() + @" {newAlias1}
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:EducationServiceCenterId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStudentUSI", "StudentUSI", "StudentUSI", "SourceEducationOrganizationId",
                            jt, Guid.NewGuid().ToString("N")
                            ),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToStudentUSI",
                        @"StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM auth.EducationOrganizationIdToStudentUSI {newAlias1} 
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM " + "auth_EducationOrganizationIdToStudentUSI".GetFullNameForView() + @" {newAlias1} 
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStudentUSI", "StudentUSI", "StudentUSI", "SourceEducationOrganizationId",
                            jt, Guid.NewGuid().ToString("N")
                            ),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStudentUSIThroughResponsibility
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToStudentUSIThroughResponsibility",
                        @"StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM auth.EducationOrganizationIdToStudentUSIThroughResponsibility {newAlias1} 
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM " + "auth_EducationOrganizationIdToStudentUSIThroughResponsibility".GetFullNameForView() +
                        @" {newAlias1} 
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStudentUSIThroughResponsibility", "StudentUSI", "StudentUSI", "SourceEducationOrganizationId", jt),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "SchoolIdToStudentUSI",
                        @"StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM auth.EducationOrganizationIdToStudentUSI {newAlias1} 
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM " + "auth_EducationOrganizationIdToStudentUSI".GetFullNameForView() + @" {newAlias1} 
                            WHERE {newAlias1}.SourceEducationOrganizationId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStudentUSI", "StudentUSI", "StudentUSI", "SourceEducationOrganizationId", jt,
                            Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStudentUSIThroughResponsibility
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "SchoolIdToStudentUSIThroughResponsibility",
                        @"StudentUSI IN (
                        SELECT {newAlias1}.StudentUSI 
                        FROM auth.EducationOrganizationIdToStudentUSIThroughResponsibility {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StudentUSI IN (
                        SELECT {newAlias1}.StudentUSI 
                        FROM " + "auth_EducationOrganizationIdToStudentUSIThroughResponsibility".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToStudentUSIThroughResponsibility", "StudentUSI", "StudentUSI", "SourceEducationOrganizationId", jt),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationServiceCenterIdToStaffUSI",
                        @"StaffUSI IN (
                        SELECT {newAlias1}.StaffUSI 
                        FROM auth.EducationOrganizationIdToStaffUSI {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StaffUSI IN (
                        SELECT {newAlias1}.StaffUSI 
                        FROM " + "auth_EducationOrganizationIdToStaffUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:EducationServiceCenterId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStaffUSI", "StaffUSI", "StaffUSI", "SourceEducationOrganizationId", jt,
                            Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("StaffUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToStaffUSI",
                        @"StaffUSI IN (
                        SELECT {newAlias1}.StaffUSI 
                        FROM auth.EducationOrganizationIdToStaffUSI {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StaffUSI IN (
                        SELECT {newAlias1}.StaffUSI 
                        FROM " + "auth_EducationOrganizationIdToStaffUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStaffUSI", "StaffUSI", "StaffUSI", "SourceEducationOrganizationId", jt,
                            Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("StaffUSI")));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "SchoolIdToStaffUSI",
                        @"StaffUSI IN (
                    SELECT {newAlias1}.StaffUSI 
                    FROM auth.EducationOrganizationIdToStaffUSI {newAlias1} 
                    WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.StaffUSI IN (
                    SELECT {newAlias1}.StaffUSI 
                    FROM " + "auth_EducationOrganizationIdToStaffUSI".GetFullNameForView() + @" {newAlias1} 
                    WHERE {newAlias1}.SourceEducationOrganizationId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToStaffUSI", "StaffUSI", "StaffUSI", "SourceEducationOrganizationId", jt),
                        (t, p) => p.HasPropertyNamed("StaffUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToParentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToParentUSI",
                        @"ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM auth.EducationOrganizationIdToParentUSI {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM " + "auth_EducationOrganizationIdToParentUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToParentUSI", "ParentUSI", "ParentUSI", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("ParentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _parentUSIToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "ParentUSIToSchoolId",
                        @"ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM auth.EducationOrganizationIdToParentUSI {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SchoolId))",
                        @"{currentAlias}.ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM " + "auth_EducationOrganizationIdToParentUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToParentUSI", "ParentUSI", "ParentUSI", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("ParentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToEducationServiceCenterId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToEducationServiceCenterId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:EducationServiceCenterId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToLocalEducationAgencyId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToLocalEducationAgencyId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToSchoolId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToLocalEducationAgencyId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationServiceCenterIdToLocalEducationAgencyId",
                        @"LocalEducationAgencyId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1}
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.LocalEducationAgencyId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1}
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:EducationServiceCenterId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToEducationOrganizationId", "LocalEducationAgencyId", "TargetEducationOrganizationId",
                            "SourceEducationOrganizationId",
                            jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("LocalEducationAgencyId")));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationServiceCenterIdToSchoolId",
                        @"SchoolId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1}
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.SchoolId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1}
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:EducationServiceCenterId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToEducationOrganizationId", "SchoolId", "TargetEducationOrganizationId",
                            "SourceEducationOrganizationId",
                            jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("SchoolId")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToSchoolId",
                        @"SchoolId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.SchoolId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(
                            w, p, "EducationOrganizationIdToEducationOrganizationId", "SchoolId", "TargetEducationOrganizationId",
                            "SourceEducationOrganizationId",
                            jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("SchoolId")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToOrganizationDepartmentId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToOrganizationDepartmentId",
                        @"OrganizationDepartmentId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.OrganizationDepartmentId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "OrganizationDepartmentId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("OrganizationDepartmentId")));

        private static readonly Lazy<FilterApplicationDetails> _organizationDepartmentIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "OrganizationDepartmentIdToSchoolId",
                        @"OrganizationDepartmentId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.OrganizationDepartmentId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "OrganizationDepartmentId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("OrganizationDepartmentId")));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToEducationOrganizationId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "CommunityOrganizationIdToEducationOrganizationId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:CommunityOrganizationId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _communityProviderIdToEducationOrganizationId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "CommunityProviderIdToEducationOrganizationId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:CommunityProviderId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToCommunityProviderId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "CommunityOrganizationIdToCommunityProviderId",
                        @"CommunityProviderId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.CommunityProviderId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:CommunityOrganizationId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "CommunityProviderId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("CommunityProviderId")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToPostSecondaryInstitutionId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToPostSecondaryInstitutionId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM auth.EducationOrganizationIdToEducationOrganizationId {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:SourceEducationOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.TargetEducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SourceEducationOrganizationId IN (:PostSecondaryInstitutionId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "TargetEducationOrganizationId", "SourceEducationOrganizationId", jt, Guid.NewGuid().ToString("N")),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        // Add non-join authorization entries for each EdOrg which can be associated with an API client

        public static FilterApplicationDetails SchoolIdToSchoolId => _schoolIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToLocalEducationAgencyId
            => _localEducationAgencyIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails CommunityProviderIdToCommunityProviderId
            => _communityProviderIdToCommunityProviderId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToCommunityOrganizationId
            => _communityOrganizationIdToCommunityOrganizationId.Value;

        public static FilterApplicationDetails PostSecondaryInstitutionIdToPostSecondaryInstitutionId
            => _postSecondaryInstitutionIdToPostSecondaryInstitutionId.Value;

        public static FilterApplicationDetails StateEducationAgencyIdToStateEducationAgencyId
            => _stateEducationAgencyIdToStateEducationAgencyId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToEducationServiceCenterId
            => _educationServiceCenterIdToEducationServiceCenterId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToStudentUSI => _educationServiceCenterIdToStudentUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStudentUSI => _localEducationAgencyIdToStudentUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStudentUSIThroughResponsibility
            => _localEducationAgencyIdToStudentUSIThroughResponsibility.Value;

        public static FilterApplicationDetails SchoolIdToStudentUSI => _schoolIdToStudentUSI.Value;

        public static FilterApplicationDetails SchoolIdToStudentUSIThroughResponsibility
            => _schoolIdToStudentUSIThroughResponsibility.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToStaffUSI => _educationServiceCenterIdToStaffUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStaffUSI => _localEducationAgencyIdToStaffUSI.Value;

        public static FilterApplicationDetails SchoolIdToStaffUSI => _schoolIdToStaffUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToParentUSI => _localEducationAgencyIdToParentUSI.Value;

        public static FilterApplicationDetails ParentUSIToSchoolId => _parentUSIToSchoolId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToEducationServiceCenterId
            => _educationOrganizationIdToEducationServiceCenterId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToLocalEducationAgencyId
            => _educationOrganizationIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToSchoolId => _educationOrganizationIdToSchoolId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToLocalEducationAgencyId => _educationServiceCenterIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToSchoolId => _educationServiceCenterIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToSchoolId => _localEducationAgencyIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToOrganizationDepartmentId
            => _localEducationAgencyIdToOrganizationDepartmentId.Value;

        public static FilterApplicationDetails OrganizationDepartmentIdToSchoolId => _organizationDepartmentIdToSchoolId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToEducationOrganizationId
            => _communityOrganizationIdToEducationOrganizationId.Value;

        public static FilterApplicationDetails CommunityProviderIdToEducationOrganizationId
            => _communityProviderIdToEducationOrganizationId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToCommunityProviderId
            => _communityOrganizationIdToCommunityProviderId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToPostSecondaryInstitutionId
            => _educationOrganizationIdToPostSecondaryInstitutionId.Value;

        private static FilterApplicationDetails CreateClaimValuePropertyFilter(string propertyName)
        {
            return new FilterApplicationDetails(
                $"{propertyName}To{propertyName}",
                $"{propertyName} IN (:{propertyName})",
                $"{{currentAlias}}.{propertyName} IN (:{propertyName})",
                (c, w, p, jt) => w.ApplyPropertyFilters(p, propertyName),
                (t, p) => p.HasPropertyNamed(propertyName));
        }

        private static string GetFullNameForView(this string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}
