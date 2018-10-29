# WeatherDataAnalysis

Assignment 1 Feedback:

*0, 1, 2 are magic numbers. Should become constants or enumerated type.

*tempDataList - noise in variable name; temp is noise and so is List.

*Weather class name is not self-documenting. What about the Weather? Is it a forecast, data, etc.?

*io namespace not following naming convention.

*In WeatherDataFormatter class instead of having to call a lot of different methods passing in the WeatherCollection. Have a single method you call that builds that summary report and then it can call all the other methods provided to build the report. This way the WeatherCollection can just be passed into this main report method.

*private readonly properties should just become data members of the class.

*Good use of LINQ.

*Empty namespaces are confusing.

*loadFile_Click method is violating SRP.


Assignment 2 Feedback:

*UI should have default values for threshold values.

*If file has errors in it, lines with errors not being displayed.

*Missing most of required output.
Lots of ReSharper warnings remain.

*Import not best class name - too generic.

*KeyValuePair not best property name, KeyValuePair of what?

*Controller::Import class shouldn't be displaying FileOpenPicker that is a view responsibility.

*getLowestHighTemps and similiar methods should return collection and then build string output from it or change the name of the method.

*CSVReader class not really doing much other than reading all lines which has nothing to do with it being a CSV file.

*isValidTemp needs only one catch block for type Exception as all handlers are doing the same thing.

*WeatherInfoCollection implements ICollection so why is property - WeatherInfos necessary?
