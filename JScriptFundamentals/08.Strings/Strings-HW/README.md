##Strings
1. Write a JavaScript function reverses string and returns it 
	* Example: `"sample"` &rarr; `"elpmas"`.
* Write a JavaScript function to check if in a given expression the brackets are put correctly.
	* Example of correct expression: `((a+b)/5-d)`.
	* Example of incorrect expression: `)(a+b))`.
* Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).
	* Example: The target substring is `"in"`. The text is as follows:
		* We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
		* The result is: 9.
* You are given a text. Write a function that changes the text in all regions:
	* `<upcase>`text`</upcase>` to uppercase.
	* `<lowcase>`text`</lowcase>` to lowercase
	* `<mixcase>`text`</mixcase>` to mix casing(random)
		* We are `<mixcase>`living`</mixcase>` in a `<upcase>`yellow submarine`</upcase>`. We `<mixcase>`don't`</mixcase>` have `<lowcase>`anything`</lowcase>` else.
		* The expected result: <br>We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.	
  * Regions can be nested

* Write a function that replaces non breaking white-spaces in a text with `&nbsp;`
* Write a function that extracts the content of a html page given as text. The function should return anything that is in a tag, without the tags: 
	* `<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>`
	* result: `Sample sitetextmore textand more...in body`
* Write a script that parses an URL address given in the format: `[protocol]://[server]/[resource]` and extracts from it the `[protocol]`, `[server]` and `[resource]` elements. Return the elements in a JSON object.
	* For example from the URL `http://www.devbg.org/forum/index.php` the following information should be extracted:
		* `{protocol: 'http', server: 'www.devbg.org',resource: '/forum/index.php'}`
'
* Write a JavaScript function that replaces in a HTML document given as string all the tags `<a href="…">…</a>` with corresponding tags `[URL=…]…/URL]`. Sample HTML fragment:
* Write a function for extracting all email addresses from given text. All substrings that match the format `<identifier>@<host>…<domain>` should be recognized as emails. Return the emails as array of strings.
* Write a program that extracts from a given text all palindromes, e.g. `"ABBA"`, `"lamal"`, `"exe"`.
* Write a function that formats a string using placeholders:
	* `var str = stringFormat('Hello {0}!', 'Peter');`
	* `//str = 'Hello Peter!';`
	* The function should work with up to 30 placeholders and all types
		* `var frmt = '{0}, {1}, {0} text {2}';`
		* `var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');`
		* `//str = '1, Pesho, 1 text Gosho'`
 












