using System;


namespace Win7_Plus_StackBy
{
    public class Property
    {
        //PropertyKey
        public Guid pk_fmtid { get; }
        public int pk_pid { get; }



        public string CanonicalName { get; }
        public string DisplayName { get; }


        //Flags to Values
        public bool IsVisible { get; }                        // PDTF_ISVIEWABLE = 0x80
        public bool IsStackable { get; }                     // PDTF_CANSTACKBY = 0x10
        public bool IsMultipleValues { get; }                // PDTF_MULTIPLEVALUES = 0x1
        public bool IsInnate { get; }                        // PDTF_ISINNATE = 0x2
        public bool IsGroup { get; }                         // PDTF_ISGROUP = 0x4
        public bool CanGroupBy { get; }                      // PDTF_CANGROUPBY = 0x8
        public bool IsTreeProperty { get; }                  // PDTF_ISTREEPROPERTY = 0x20
        public bool IncludeInFullTextQuery { get; }          // PDTF_INCLUDEINFULLTEXTQUERY = 0x40
        public bool IsQueryable { get; }                     // PDTF_ISQUERYABLE = 0x100
        public bool CanBePurged { get; }                     // PDTF_CANBEPURGED = 0x200
        public bool CanSearchRawValue { get; }               // PDTF_SEARCHRAWVALUE = 0x400
        public bool DontCoerceEmptyStrings { get; }          // PDTF_DONTCOERCEEMPTYSTRINGS = 0x800
        public bool AlwaysInSupplementalStore { get; }       // PDTF_ALWAYSINSUPPLEMENTALSTORE = 0x1000
        public bool IsSystemProperty { get; }                // PDTF_ISSYSTEMPROPERTY = unchecked((int)0x80000000)

        public Property(
            Guid pk_fmtid,
            int pk_pid,
            string canonicalName,
            string displayName,
            bool isVisible,
            bool isStackable,
            bool isMultipleValues,
            bool isInnate,
            bool isGroup,
            bool canGroupBy,
            bool isTreeProperty,
            bool includeInFullTextQuery,
            bool isQueryable,
            bool canBePurged,
            bool canSearchRawValue,
            bool dontCoerceEmptyStrings,
            bool alwaysInSupplementalStore,
            bool isSystemProperty)
        {
            this.pk_fmtid = pk_fmtid;
            this.pk_pid = pk_pid;
            this.CanonicalName = canonicalName;
            this.DisplayName = displayName;
            this.IsVisible = isVisible;
            this.IsStackable = isStackable;
            this.IsMultipleValues = isMultipleValues;
            this.IsInnate = isInnate;
            this.IsGroup = isGroup;
            this.CanGroupBy = canGroupBy;
            this.IsTreeProperty = isTreeProperty;
            this.IncludeInFullTextQuery = includeInFullTextQuery;
            this.IsQueryable = isQueryable;
            this.CanBePurged = canBePurged;
            this.CanSearchRawValue = canSearchRawValue;
            this.DontCoerceEmptyStrings = dontCoerceEmptyStrings;
            this.AlwaysInSupplementalStore = alwaysInSupplementalStore;
            this.IsSystemProperty = isSystemProperty;
        }


        public string ToStringDetailed()
        {
            return $"PropertyKey:\n" +
                   $"  Format ID: {pk_fmtid}\n" +
                   $"  Property ID: {pk_pid}\n" +
                   $"Names:\n" +
                   $"  Canonical Name: {CanonicalName}\n" +
                   $"  Display Name: {DisplayName}\n" +
                   $"Flags:\n" +
                   $"  Is Visible: {IsVisible}\n" +
                   $"  Is Stackable: {IsStackable}\n" +
                   $"  Is Multiple Values: {IsMultipleValues}\n" +
                   $"  Is Innate: {IsInnate}\n" +
                   $"  Is Group: {IsGroup}\n" +
                   $"  Can Group By: {CanGroupBy}\n" +
                   $"  Is Tree Property: {IsTreeProperty}\n" +
                   $"  Include In Full Text Query: {IncludeInFullTextQuery}\n" +
                   $"  Is Queryable: {IsQueryable}\n" +
                   $"  Can Be Purged: {CanBePurged}\n" +
                   $"  Can Search Raw Value: {CanSearchRawValue}\n" +
                   $"  Don't Coerce Empty Strings: {DontCoerceEmptyStrings}\n" +
                   $"  Always In Supplemental Store: {AlwaysInSupplementalStore}\n" +
                   $"  Is System Property: {IsSystemProperty}";
        }

        public override string ToString()
        {
            return $"{DisplayName} | {CanonicalName}";
        }


    }
}
