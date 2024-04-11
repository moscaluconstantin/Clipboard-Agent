## Release Description: Introducing cpbagent

We are thrilled to announce the launch of **cpbagent**, a versatile command-line tool designed to streamline text conversion between different character sets with ease.

### Features:
- **Automatic Charset Detection**: With `cpbagent`, there's no need to manually specify the character set. Simply run the command without arguments, and `cpbagent` intelligently detects the initial charset of the text from your clipboard.
   
- **Flexible Conversion Options**: Whether you're working with English (`en`), Russian (`ru`), or Romanian (`ro`) text, `cpbagent` has you covered. You can convert text to one of these supported charsets seamlessly.

- **Simple CLI Interface**: `cpbagent` offers a user-friendly CLI interface, making it accessible for users of all levels. Just type `cpbagent` followed by your desired conversion target, and let `cpbagent` handle the rest.

- **Custom Charset Conversion**: For advanced users, `cpbagent` allows specifying both the source and target charsets. This level of customization ensures precise conversion tailored to your specific needs.

### Usage Examples:
- **Auto-detect charset and convert between English and Russian**:
```bash
cpbagent
```

- **Convert text from clipboard to Russian**:
```bash
cpbagent ru
```

- **Convert text from clipboard in Romanian charset to English**:
```bash
cpbagent ro en
```

### Get Started:
Ready to streamline your text conversion tasks? Get started with `cpbagent` today by installing the package and unleash the power of seamless charset conversion at your fingertips.

```bash
dotnet tool install --global --add-source ./the_package_location your_tool_name
