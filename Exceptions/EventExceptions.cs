namespace precio_summer_project.Exceptions;

public class EventNameEmptyException(string exception = "Event name can't be empty")
    : Exception(exception);

public class EventDescriptionEmptyException(string exception = "Event description can't be empty")
    : Exception(exception);

public class EventLocationEmptyException(string exception = "Event location can't be empty")
    : Exception(exception);

public class EventStartDateException(
    string exception = "Event starting date can't be earlier than todays date"
) : Exception(exception);

public class EventStartTimeException(
    string exception = "Event starting time can't be earlier than todays time"
) : Exception(exception);

public class EventEndTimeException(
    string exception = "Event ending time can't be earlier than event starting time"
) : Exception(exception);

public class EventEndDateException(
    string exception = "Event ending date can't be earlier than event starting date"
) : Exception(exception);

public class EventNotFoundException(string exception = "Could not find event")
    : Exception(exception);
