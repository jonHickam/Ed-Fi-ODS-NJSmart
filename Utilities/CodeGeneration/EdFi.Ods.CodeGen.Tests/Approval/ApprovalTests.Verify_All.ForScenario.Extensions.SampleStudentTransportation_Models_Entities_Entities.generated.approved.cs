using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Adapters;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Entities.Common.SampleStudentTransportation;
using Newtonsoft.Json;

// Aggregate: StudentTransportation

namespace EdFi.Ods.Entities.NHibernate.StudentTransportationAggregate.SampleStudentTransportation
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="StudentTransportation"/> entity.
    /// </summary>
    public class StudentTransportationReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string AMBusNumber { get; set; }
        public virtual string PMBusNumber { get; set; }
        public virtual int SchoolId { get; set; }
        public virtual int StudentUSI { get; set; }
        // -------------------------------------------------------------

        /// <summary>
        /// The id of the referenced entity (used as the resource identifier in the API).
        /// </summary>
        public virtual Guid? Id { get; set; }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        public virtual string Discriminator { get; set; }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("AMBusNumber", AMBusNumber);
            keyValues.Add("PMBusNumber", PMBusNumber);
            keyValues.Add("SchoolId", SchoolId);
            keyValues.Add("StudentUSI", StudentUSI);

            return keyValues;
        }

        #region Overrides for Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var compareTo = obj as IHasPrimaryKeyValues;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            var theseKeys = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();
            var thoseKeys = compareTo.GetPrimaryKeyValues();

            foreach (DictionaryEntry entry in theseKeys)
            {
                if (!entry.Value.Equals(thoseKeys[entry.Key]))
                    return false;
            }

            return true;
        }

        private const int HashMultiplier = 31; // or 33, 37, 39, 41

        public override int GetHashCode()
        {
            unchecked
            {
                var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

                if (keyValues.Count == 0)
                    return base.GetHashCode();

                int hashCode = this.GetType().GetHashCode();

                foreach (DictionaryEntry entry in keyValues)
                {
                    if (entry.Value == null)
                        continue;

                    hashCode = (hashCode*HashMultiplier) ^ entry.Value.GetHashCode();
                }

                return hashCode;
            }
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the samplestudenttransportation.StudentTransportation table of the StudentTransportation aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("samplestudenttransportation")]
    [ExcludeFromCodeCoverage]
    public class StudentTransportation : AggregateRootWithCompositeKey,
        Entities.Common.SampleStudentTransportation.IStudentTransportation, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.SampleStudentTransportation.IStudentTransportationSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StudentTransportation()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(6), NoDangerousText, NoWhitespace]
        public virtual string AMBusNumber  { get; set; }
        [DomainSignature, RequiredWithNonDefault, StringLength(6), NoDangerousText, NoWhitespace]
        public virtual string PMBusNumber  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int SchoolId  { get; set; }
        [Display(Name="StudentUniqueId")]
        [DomainSignature, RequiredWithNonDefault("Student")]
        public virtual int StudentUSI 
        {
            get
            {
                if (_studentUSI == default(int))
                    _studentUSI = PersonUniqueIdToUsiCache.GetCache().GetUsi("Student", _studentUniqueId);

                return _studentUSI;
            } 
            set
            {
                _studentUSI = value;
            }
        }

        private int _studentUSI;
        private string _studentUniqueId;

        [RequiredWithNonDefault]
        public virtual string StudentUniqueId
        {
            get
            {
                if (_studentUniqueId == null)
                    _studentUniqueId = PersonUniqueIdToUsiCache.GetCache().GetUniqueId("Student", _studentUSI);
                    
                return _studentUniqueId;
            }
            set
            {
                if (_studentUniqueId != value)
                        _studentUSI = default(int);

                _studentUniqueId = value;
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal EstimatedMilesFromSchool  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.EducationOrganizationAggregate.EdFi.EducationOrganizationReferenceData SchoolReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the School resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.SampleStudentTransportation.IStudentTransportation.SchoolResourceId
        {
            get { return SchoolReferenceData?.Id; }
            set { }
        }

        public virtual NHibernate.StudentAggregate.EdFi.StudentReferenceData StudentReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the Student discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.SampleStudentTransportation.IStudentTransportation.StudentDiscriminator
        {
            get { return StudentReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the Student resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.SampleStudentTransportation.IStudentTransportation.StudentResourceId
        {
            get { return StudentReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("AMBusNumber", AMBusNumber);
            keyValues.Add("PMBusNumber", PMBusNumber);
            keyValues.Add("SchoolId", SchoolId);
            keyValues.Add("StudentUSI", StudentUSI);

            return keyValues;
        }

        #region Overrides for Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var compareTo = obj as IHasPrimaryKeyValues;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            var theseKeys = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();
            var thoseKeys = compareTo.GetPrimaryKeyValues();

            foreach (DictionaryEntry entry in theseKeys)
            {
                if (entry.Value is string)
                {
                    if (!((string) entry.Value).EqualsIgnoreCase((string) thoseKeys[entry.Key]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!entry.Value.Equals(thoseKeys[entry.Key]))
                        return false;
                }
            }

            return true;
        }

        private const int HashMultiplier = 31; // or 33, 37, 39, 41

        public override int GetHashCode()
        {
            unchecked
            {
                var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

                if (keyValues.Count == 0)
                    return base.GetHashCode();

                int hashCode = this.GetType().GetHashCode();

                foreach (DictionaryEntry entry in keyValues)
                {
                    if (entry.Value == null)
                        continue;

                    if (entry.Value is string)
                    {
                        hashCode = (hashCode*HashMultiplier) ^ ((string) entry.Value).ToLower().GetHashCode();
                    }
                    else
                    {
                        hashCode = (hashCode*HashMultiplier) ^ entry.Value.GetHashCode();
                    }
                }

                return hashCode;
            }
        }
        #endregion
        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.SampleStudentTransportation.IStudentTransportation)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.SampleStudentTransportation.IStudentTransportation) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isEstimatedMilesFromSchoolSupported = true;
        bool Entities.Common.SampleStudentTransportation.IStudentTransportationSynchronizationSourceSupport.IsEstimatedMilesFromSchoolSupported
        {
            get { return _isEstimatedMilesFromSchoolSupported; }
            set { _isEstimatedMilesFromSchoolSupported = value; }
        }

        // -----------------------------------------
    }
}
