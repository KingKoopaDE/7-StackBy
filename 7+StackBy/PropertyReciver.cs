using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


namespace Win7_Plus_StackBy
{
    class PropertyReciver
    {

        public static List<Property> RecivePropertys(PROPDESC_ENUMFILTER filter)
        {

            List<Property> propertylist = new List<Property>();

            PSEnumeratePropertyDescriptions(filter, typeof(IPropertyDescriptionList).GUID, out IPropertyDescriptionList list);

            for (int i = 0; i < list.GetCount(); i++)
            {
                IPropertyDescription pd = list.GetAt(i, typeof(IPropertyDescription).GUID);

                PROPERTYKEY pk = pd.GetPropertyKey();


                // Flag to bool
                bool isVisible = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISVIEWABLE) == PROPDESC_TYPE_FLAGS.PDTF_ISVIEWABLE;
                bool isStackable = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_CANSTACKBY) == PROPDESC_TYPE_FLAGS.PDTF_CANSTACKBY;
                bool isMultipleValues = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_MULTIPLEVALUES) == PROPDESC_TYPE_FLAGS.PDTF_MULTIPLEVALUES;
                bool isInnate = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISINNATE) == PROPDESC_TYPE_FLAGS.PDTF_ISINNATE;
                bool isGroup = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISGROUP) == PROPDESC_TYPE_FLAGS.PDTF_ISGROUP;
                bool canGroupBy = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_CANGROUPBY) == PROPDESC_TYPE_FLAGS.PDTF_CANGROUPBY;
                bool isTreeProperty = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISTREEPROPERTY) == PROPDESC_TYPE_FLAGS.PDTF_ISTREEPROPERTY;
                bool includeInFullTextQuery = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_INCLUDEINFULLTEXTQUERY) == PROPDESC_TYPE_FLAGS.PDTF_INCLUDEINFULLTEXTQUERY;
                bool isQueryable = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISQUERYABLE) == PROPDESC_TYPE_FLAGS.PDTF_ISQUERYABLE;
                bool canBePurged = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_CANBEPURGED) == PROPDESC_TYPE_FLAGS.PDTF_CANBEPURGED;
                bool canSearchRawValue = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_SEARCHRAWVALUE) == PROPDESC_TYPE_FLAGS.PDTF_SEARCHRAWVALUE;
                bool dontCoerceEmptyStrings = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_DONTCOERCEEMPTYSTRINGS) == PROPDESC_TYPE_FLAGS.PDTF_DONTCOERCEEMPTYSTRINGS;
                bool alwaysInSupplementalStore = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ALWAYSINSUPPLEMENTALSTORE) == PROPDESC_TYPE_FLAGS.PDTF_ALWAYSINSUPPLEMENTALSTORE;
                bool isSystemProperty = pd.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISSYSTEMPROPERTY) == PROPDESC_TYPE_FLAGS.PDTF_ISSYSTEMPROPERTY;


                propertylist.Add(new Property(
                                 pk.fmtid,
                                 pk.pid,
                                 GetCanonicalName(pd),
                                 GetDisplayName(pd),
                                 isVisible,
                                 isStackable,
                                 isMultipleValues,
                                 isInnate,
                                 isGroup,
                                 canGroupBy,
                                 isTreeProperty,
                                 includeInFullTextQuery,
                                 isQueryable,
                                 canBePurged,
                                 canSearchRawValue,
                                 dontCoerceEmptyStrings,
                                 alwaysInSupplementalStore,
                                 isSystemProperty
                             ));


               

            }

            

            return propertylist.OrderBy(x=>x.DisplayName).ToList();
        }

        public struct PROPERTYKEY
        {
            public Guid fmtid;
            public int pid;
        }

        public enum PROPDESC_ENUMFILTER
        {
            PDEF_ALL = 0,
            PDEF_SYSTEM = 1,
            PDEF_NONSYSTEM = 2,
            PDEF_VIEWABLE = 3,
            PDEF_QUERYABLE = 4,
            PDEF_INFULLTEXTQUERY = 5,
            PDEF_COLUMN = 6,
        }

        [Flags]
        public enum PROPDESC_TYPE_FLAGS
        {
            PDTF_DEFAULT = 0,
            PDTF_MULTIPLEVALUES = 0x1,
            PDTF_ISINNATE = 0x2,
            PDTF_ISGROUP = 0x4,
            PDTF_CANGROUPBY = 0x8,
            PDTF_CANSTACKBY = 0x10,
            PDTF_ISTREEPROPERTY = 0x20,
            PDTF_INCLUDEINFULLTEXTQUERY = 0x40,
            PDTF_ISVIEWABLE = 0x80,
            PDTF_ISQUERYABLE = 0x100,
            PDTF_CANBEPURGED = 0x200,
            PDTF_SEARCHRAWVALUE = 0x400,
            PDTF_DONTCOERCEEMPTYSTRINGS = 0x800,
            PDTF_ALWAYSINSUPPLEMENTALSTORE = 0x1000,
            PDTF_ISSYSTEMPROPERTY = unchecked((int)0x80000000),
            PDTF_MASK_ALL = unchecked((int)0x80001fff),
        }

        [DllImport("propsys")]
        public static extern int PSEnumeratePropertyDescriptions(PROPDESC_ENUMFILTER filterOn, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IPropertyDescriptionList ppv);

        [ComImport, Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyDescriptionList
        {
            int GetCount();
            [return: MarshalAs(UnmanagedType.Interface)]
            IPropertyDescription GetAt(int iElem, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);
        }

        [ComImport, Guid("6F79D558-3E96-4549-A1D1-7D75D2288814"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPropertyDescription
        {
            PROPERTYKEY GetPropertyKey();
            [PreserveSig] int GetCanonicalName(out IntPtr name);
            int GetPropertyType();
            [PreserveSig] int GetDisplayName(out IntPtr name);
            [PreserveSig] int GetEditInvitation(out IntPtr name);
            PROPDESC_TYPE_FLAGS GetTypeFlags(PROPDESC_TYPE_FLAGS mask);
            // following methods are undefined in this code since we don't need it
        }
        private static string GetCanonicalName(IPropertyDescription pd)
        {
            IntPtr name;
            int result = pd.GetCanonicalName(out name);

            if (result == 0)
            {
                string canonicalName = Marshal.PtrToStringUni(name);
                Marshal.FreeCoTaskMem(name);
                return canonicalName;

            }

            else
            {
                return "N/A";
            }

        }

        private static string GetDisplayName(IPropertyDescription pd)
        {
            IntPtr name;
            int result = pd.GetDisplayName(out name);

            if (result == 0)
            {
                string displayname = Marshal.PtrToStringUni(name);
                Marshal.FreeCoTaskMem(name);
                return displayname;

            }

            else
            {
                return "N/A";
            }


        }


    }
}
