package dbus;

import org.junit.Test;

import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import static org.assertj.core.api.Assertions.assertThat;

public abstract class TimelineTest<E extends Date, T extends Timeline<E>> {

    abstract T construct(List<E> input);
    abstract E date(long time);

    private final T timeline = construct(dates(0, 5, 9));

    private List<E> dates(long... times) {
        return Arrays.stream(times)
                .mapToObj(this::date)
                .collect(Collectors.toList());
    }

    @Test(expected = NullPointerException.class)
    public void constructor_should_throw_NullPointerException_when_given_date_list_is_null() {
        // given
        // when
        construct(null);
        // then
    }

    @Test(expected = IllegalArgumentException.class)
    public void constructor_should_throw_IllegalArgumentException_when_given_date_list_is_not_ordered() {
        // given
        // when
        construct(dates(1, 2, 0));
        // then
    }

    @Test(expected = NullPointerException.class)
    public void add_should_throw_NullPointerException_when_given_date_is_null() {
        // given
        // when
        timeline.add(null);
        // then
    }

    @Test
    public void add_should_modify_the_timeline_when_given_date_is_not_already_in() {
        // given
        E date = date(4);
        // when
        timeline.add(date);
        // then
        assertThat(timeline.getDates()).isEqualTo(dates(0, 4, 5, 9));
    }

    @Test
    public void add_should_not_modify_the_timeline_when_given_date_is_already_in() {
        // given
        E date = date(5);
        // when
        timeline.add(date);
        // then
        assertThat(timeline.getDates()).isEqualTo(dates(0, 5, 9));
    }

    @Test(expected = NullPointerException.class)
    public void remove_should_throw_NullPointerException_when_provided_predicate_is_null() {
        // given
        // when
        timeline.remove(null);
        // then
    }

    @Test
    public void remove_should_remove_one_element_when_only_one_element_satisfy_the_predicate() {
        // given
        // when
        timeline.remove(d -> d.equals(new Date(5)));
        // then
        assertThat(timeline.getDates()).isEqualTo(dates(0, 9));
    }

    @Test
    public void remove_should_keep_at_least_two_elements() {
        // given
        // when
        timeline.remove(d -> true);
        // then
        assertThat(timeline.getDates().size()).isEqualTo(2);
    }

}