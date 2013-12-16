CRUD BOOKING APPLICATION
----------------------------------------------------------
Andrew Bowen


SETUP
----------------------------------------------------------
- Visual Studio MUST be run in Administrator mode to work (Shift + Right Click on TaskBar icon -> Run as administrator)
- Set MyBusiness.BookAd.Presentation.Wpf as startup project
- If there are issues with running the Solution, perform a clean, rebuild, and start again
- Application was built using VS2012 on Windows 8.1
- All 3rd party frameworks were installed using NuGet


ARCHITECTURE LAYOUT SUMMARY
----------------------------------------------------------
I've divided it into 5 main sections

1. Presentation Layer (WPF)
2. Service Layer (WCF)
3. Business Layer
4. Data Access Layer (EF)
5. Common 


DIAGNOSTICS
----------------------------------------------------------
SERVER
- The WCF project uses log4net to log to a file (log4net.log) to it's application folder
- I kept the logging relatively simple: Debug & Error messages 
- It's currently setup for Debug, this can be change in the WCF project's App.Config

CLIENT
- The WPF project catches the majority unhandled exceptions and will notify the user it's logged to a file (UnhandledException.txt)
- Ideally this means the application can still be usable after an unexpected exception
- Add an exception to the ListViewModel's UpdateButton method to highlight this


3RD PARTY FRAMEWORKS
----------------------------------------------------------
NuGet
http://www.nuget.org/
- Makes it significantly easier to add & maintain frameworks to solutions

Fluent Validation
http://fluentvalidation.codeplex.com/
- I love the syntax of building the validation rules as they can written to look like user stories 
- Minimal setup required to get working in existing application
- Easy to include globalization if required in future

Caliburn.Micro
http://caliburnmicro.codeplex.com/
- Uses convention over configuration for MVVM. It's rare to see a developer implement MVVM the same as another developer based off a previous project
- Includes a simple IoC that I used to decouple the WCF from WPF

Log4Net
http://logging.apache.org/log4net/
- Easy to setup and highly configurable, even for basic scenarios such as logging to a file

Extended WPF Toolkit Community Edition
http://wpftoolkit.codeplex.com/
- I needed a time control and didn't want to spend the time reinventing the wheel


ARCHITECTURE & DESIGN DECISIONS
----------------------------------------------------------
- Projects had Warnings treated as errors turned on
- Shorter project names instead of descriptive ones to reduce the chance of hitting Microsoft’s 260 build character limit [1]
- I could have shorted project folders & assemblies, but I like to keep folders : namespaces : assemblies as 1 : 1 : 1
- Stored the date in UTC to try reduce misunderstandings when comparing dates due to the variations in DST, changing timezones, etc. [2]
- I’ve inferred this project is an internal enterprise, so by sharing the business logic between client & server is a non-issue, compared to the benefits of DRY
- Viewed the Services project similar as the line between trusted & untrusted sources, therefore do not expose stack traces, etc to consumers
- Maintained Visual Studio DesignTime availibility with the Views, however this does lead to some code artifacts
- Similar UI appearance to that of Windows 8 / Windows Phone
- This makes it quicker & easier for developers to design for and (hopefully) easier transfer to touch devices
- Followed the Arrange/Act/Assert pattern for testing and had the names read as close to user stories [3]
- Application maybe used in different timezones, therefore timezone offsets are important and should be visible to the user
- This was an internal application, so security & web access considerations were unnecessary
- Ads would only be reserved for dates in the future
- 15,30,45,60 second durations are more like recommendations, not constraints, so I didn’t enforce referential integrity in the database on these values

[1] http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation

[2] http://infiniteundo.com/post/25326999628/falsehoods-programmers-believe-about-time

[3] http://xp123.com/articles/3a-arrange-act-assert/