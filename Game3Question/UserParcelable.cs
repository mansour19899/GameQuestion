using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace Game3Question
{
    class UserParcelable : Java.Lang.Object, IParcelable
    {
        public Person person { get; set; }
        public UserParcelable()
        {
        }

        private static readonly GenericParcelableCreator<UserParcelable> _creator
            = new GenericParcelableCreator<UserParcelable>((parcel) => new UserParcelable(parcel));

        [ExportField("CREATOR")]
        public static GenericParcelableCreator<UserParcelable> GetCreator()
        {
            return _creator;
        }


        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {

            dest.WriteInt(person.Id);
            dest.WriteInt(person.Score);
            dest.WriteInt(person.Level);
            dest.WriteString(person.Name);

        }

        private UserParcelable(Parcel parcel)
        {
            person = new Person
            {
                Id = parcel.ReadInt(),
                Score = parcel.ReadInt(),
                Level = parcel.ReadInt(),
                Name = parcel.ReadString(),

            };
        }

    }

    public class GenericParcelableCreator<T> : Java.Lang.Object, IParcelableCreator where T : Java.Lang.Object, new()
    {
        /// <summary>
        /// Function for the creation of a parcel.
        /// </summary>
        private readonly Func<Parcel, T> _createFunc;

        /// <summary>
        /// Initialize an instance of the GenericParcelableCreator.
        /// </summary>
        public GenericParcelableCreator(Func<Parcel, T> createFromParcelFunc)
        {
            _createFunc = createFromParcelFunc;
        }

        /// <summary>
        /// Create a parcelable from a parcel.
        /// </summary>
        public Java.Lang.Object CreateFromParcel(Parcel parcel)
        {
            return _createFunc(parcel);
        }

        /// <summary>
        /// Create an array from the parcelable class.
        /// </summary>
        public Java.Lang.Object[] NewArray(int size)
        {
            return new T[size];
        }
    }

}