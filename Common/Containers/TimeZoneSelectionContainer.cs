using Common.Interfaces;
using System;

namespace Common
{
    public class TimeZoneSelectionContainer : ITimeZoneSelectionContainer
    {
        public TimeZoneInfo CurrentTimeZoneInfo
        {
            get
            {
                return _currentTimeZoneInfo;
            }
            private set
            {
                _currentTimeZoneInfo = value;

                if (CurrentTimeZoneChanged != null)
                {
                    CurrentTimeZoneChanged(this, new EventArgs());
                }
            }
        }
        private TimeZoneInfo _currentTimeZoneInfo;

        public TimeZoneInfo ObjectTimeZoneInfo
        {
            get
            {
                return _objectTimeZoneInfo;
            }
            private set
            {
                _objectTimeZoneInfo = value;

                if (ObjectTimeZoneChanged != null)
                {
                    ObjectTimeZoneChanged(this, new EventArgs());
                }
            }
        }
        private TimeZoneInfo _objectTimeZoneInfo;

        public void SetCurrentTimeZoneInfo(TimeZoneInfo timeZoneInfo)
        {
            CurrentTimeZoneInfo = timeZoneInfo;
        }

        public void SetCurrentTimeZoneInfo(string timeZoneId)
        {
            CurrentTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }

        public void SetObjectTimeZoneInfo(TimeZoneInfo timeZoneInfo)
        {
            ObjectTimeZoneInfo = timeZoneInfo;
        }

        public void SetObjectTimeZoneInfo(string timeZoneId)
        {
            ObjectTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }

        public event EventHandler CurrentTimeZoneChanged;

        public event EventHandler ObjectTimeZoneChanged;
    }
}
