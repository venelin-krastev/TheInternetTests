# TheInternetTests

![Tests](https://github.com/venelin-krastev/TheInternetTests/actions/workflows/tests.yml/badge.svg)

Automated UI tests for [The Internet](https://the-internet.herokuapp.com) — a practice site for Selenium automation.

## Tech Stack

- **C# / .NET 10**
- **Selenium WebDriver 4.43**
- **NUnit 4.3**
- **ChromeDriver**

## Test Coverage

| Class | Page | Tests |
|---|---|---|
| `LoginTests.cs` | `/login` | 4 |
| `DropdownTests.cs` | `/dropdown` | 4 |
| `CheckboxTests.cs` | `/checkboxes` | 4 |
| `AlertTests.cs` | `/javascript_alerts` | 5 |
| `DynamicLoadingTests.cs` | `/dynamic_loading` | 2 |
| `IFrameTests.cs` | `/iframe` | 3 |
| `MultipleWindowsTests.cs` | `/windows` | 3 |
| `HoverTests.cs` | `/hovers` | 6 |
| `DragAndDropTests.cs` | `/drag_and_drop` | 2 |
| `FileUploadTests.cs` | `/upload` | 2 |
| `ContextMenuTests.cs` | `/context_menu` | 3 |

**Total: 38 tests**

## Project Structure

```
TheInternetTests/
  Pages/
    LoginPage.cs
    DropdownPage.cs
    CheckboxPage.cs
    AlertPage.cs
    DynamicLoadingPage.cs
    IFramePage.cs
    MultipleWindowsPage.cs
    HoverPage.cs
    DragAndDropPage.cs
  BaseTest.cs                  # Abstract base — shared SetUp, TearDown, screenshot on failure
  DriverFactory.cs             # ChromeDriver factory — headless mode via CI env var
  LoginTests.cs
  DropdownTests.cs
  CheckboxTests.cs
  AlertTests.cs
  DynamicLoadingTests.cs
  IFrameTests.cs
  MultipleWindowsTests.cs
  HoverTests.cs
  DragAndDropTests.cs
```

## Key Concepts Demonstrated

- **Page Object Model (POM)** — 10 Page Objects, one per page
- **BaseTest abstraction** — shared `[SetUp]` and `[TearDown]`, screenshot on failure saved to `TestDirectory`
- **Actions class** — hover interactions and drag & drop
- **File upload** — `SendKeys()` on file input bypasses OS dialog
- **Context menu** — `Actions.ContextClick()` for right-click, `SwitchTo().Alert()` for JS alert
- **WebDriverWait** — explicit waits with lambda conditions, no `Thread.Sleep`
- **SelectElement** — dropdown interaction
- **JS Alerts** — `SwitchTo().Alert()` for alert, confirm, and prompt dialogs
- **iFrame navigation** — `SwitchTo().Frame()` and `DefaultContent()`
- **Multi-window handling** — `WindowHandles` and `SwitchTo().Window()`
- **GitHub Actions CI/CD** — headless Chrome on every push via `CI=true` env var

## Tests

### LoginTests.cs
| Test | Description |
|---|---|
| `SuccessfulLoginRedirectsToSecurePage` | Verifies redirect to /secure after valid login |
| `SuccessfulLoginShowsSuccessMessage` | Verifies success flash message |
| `InvalidPasswordShowsErrorMessage` | Verifies error message on wrong password |
| `InvalidUsernameShowsErrorMessage` | Verifies error message on wrong username |

### DropdownTests.cs
| Test | Description |
|---|---|
| `SelectOptionOneByText` | Selects Option 1 by visible text |
| `SelectOptionTwoByValue` | Selects Option 2 by value attribute |
| `CanSelectOption("Option 1")` | Parameterized selection test |
| `CanSelectOption("Option 2")` | Parameterized selection test |

### CheckboxTests.cs
| Test | Description |
|---|---|
| `FirstCheckboxIsUncheckedByDefault` | Verifies checkbox 1 is unchecked on load |
| `SecondCheckboxIsCheckedByDefault` | Verifies checkbox 2 is checked on load |
| `CanCheckFirstCheckbox` | Toggles checkbox 1 and verifies checked state |
| `CanUncheckSecondCheckbox` | Toggles checkbox 2 and verifies unchecked state |

### AlertTests.cs
| Test | Description |
|---|---|
| `AlertShowsCorrectText` | Verifies alert text before accepting |
| `AcceptingAlertShowsResult` | Accepts JS alert and verifies result |
| `AcceptingConfirmShowsResult` | Accepts confirm dialog and verifies result |
| `DismissingConfirmShowsResult` | Dismisses confirm dialog and verifies result |
| `PromptAcceptsTypedText` | Types text in prompt and verifies result |

### DynamicLoadingTests.cs
| Test | Description |
|---|---|
| `Example1ShowsHelloWorldAfterLoad` | Waits for hidden element to become visible |
| `Example2ShowsHelloWorldAfterLoad` | Waits for element added to DOM after delay |

### IFrameTests.cs
| Test | Description |
|---|---|
| `IFrameContainsDefaultText` | Verifies TinyMCE editor loads with default text |
| `CanSetTextInIFrame` | Sets text via JavaScript inside iFrame |
| `CanSwitchBackToMainPage` | Switches back to main page from iFrame context |

### MultipleWindowsTests.cs
| Test | Description |
|---|---|
| `ClickingLinkOpensNewWindow` | Verifies a second window is opened |
| `NewWindowHasCorrectTitle` | Switches to new window and checks its title |
| `CanSwitchBackToMainWindow` | Switches back to main window and verifies title |

### HoverTests.cs
| Test | Description |
|---|---|
| `HoverOverFirstAvatar_ShowsUserOneCaptionText` | Hover over avatar 1 reveals user1 caption |
| `HoverOverSecondAvatar_ShowsUserTwoCaptionText` | Hover over avatar 2 reveals user2 caption |
| `HoverOverAvatar_MakesViewProfileLinkVisible` | View profile link appears on hover |
| `HoverOverAvatar_ShowsCorrectUsername(0, "user1")` | Parameterized hover test |
| `HoverOverAvatar_ShowsCorrectUsername(1, "user2")` | Parameterized hover test |
| `HoverOverAvatar_ShowsCorrectUsername(2, "user3")` | Parameterized hover test |

### DragAndDropTests.cs
| Test | Description |
|---|---|
| `DragAOntoB_ColumnAHeaderChangesToB` | After drag, column A displays header B |
| `DragAOntoB_ColumnBHeaderChangesToA` | After drag, column B displays header A |

### FileUploadTests.cs
| Test | Description |
|---|---|
| `UploadFile_ShowsUploadedFileName` | Uploaded filename appears on page after upload |
| `UploadFile_ShowsSuccessHeader` | Page shows "File Uploaded!" header after upload |

## How to Run

```bash
dotnet test
```

## Author

Venelin Krastev — Junior QA Automation Engineer, Sofia
