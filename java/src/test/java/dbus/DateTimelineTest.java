package dbus;

import java.util.Date;

public abstract class DateTimelineTest<T extends Timeline<Date>> extends TimelineTest<Date, T> {
    @Override
    Date date(long time) {
        return new Date(time);
    }
}
