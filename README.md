<h1>Overview</h1>

This code sample accompanies the lecture 'C-Sharp.NET Secure Coding Guidelines' associated with the Secure Software Development module delivered at ATU Sligo.

The associated Visual Studio solution comprises seven C# projects intended to demonstrate the use of Reflection (and how Reflection can be used to circumvent access modifiers in C#). Projects 01 - 05 demonstrate these concepts in .NET (Core - version 6.0+), whilst Projects 06 - 07 demonstrate these concepts in .NET Framework (version 4.6+):

<ul>
<li>01 EXE - No Protection Against Reflection.</li>
<li>02 Invoking EXE (01) Using Reflection.</li>
<li>03 EXE - Protected Against Reflection.</li>
<li>04 Invoking EXE (03) That Prevents Reflection Being Used.</li>
<li>05 Listing Classes And Methods In Assembly Using Reflection.</li>
<li>06 EXE - Protected Against Reflection Using Attributes.</li>
<li>07 Invoking EXE (06) That Prevents Reflection.</li>
</ul>

<h2>01 EXE - No Protection Against Reflection</h2>
<ol>
<li>C# Console Application.</li>
<li><code>Main</code> Method is defined in <code>Program.cs</code>.</li>
<li><code>Main</code> Method creates an instance of <code>Internal_Class</code>.</li>
<li>
<code>Internal_Class</code>:
<ul>
<li>Class is defined with the <code>internal</code> access modifier.</li>
<li>Contains the Method, <code>Private_Method</code>, which has been defined with the <code>private</code> access modifier (and which is invoked when the constructor for the <code>Internal_Class</code> Class is executed).</li>
</ul>
</li>
</ol>

<hr />

<h2>02 Invoking EXE (01) Using Reflection</h2>
<ol>
<li>C# Console Application</li>
<li><code>Main</code> Method is defined in <code>Program.cs</code>.</li>
<li><code>Main</code> Method creates an instance of <code>Internal_Class</code> from the previous project (<em>'01 EXE - No Protection Against Reflection'</em>) using Reflection (<em>circumventing the associated <code>internal</code> access modifier</em>).</li>
<li><code>Main</code> Method also invokes the previously mentioned <code>Private_Method</code> Method using Reflection (<em>circumventing the associated <code>private</code> access modifier</em>).</li>
</ol>

<hr />

<h2>03 EXE - Protected Against Reflection</h2>
<ol>
<li>Modified version of '<em>01 EXE - No Protection Against Reflection</em>'.</li>
<li>The Constructor for <code>Internal_Class</code> has been modified to only allow it to be invoked by the <code>Main</code> Method of the <code>Program</code> Class contained within the '<em>03 EXE - Protected Against Reflection.dll</em>' Assembly.</li>
<li>The Method, <code>Private_Method</code>, has been modified to only allow it to be invoked by the Constructor for the <code>Internal_Class</code> Class contained within the '<em>03 EXE - Protected Against Reflection.dll</em>' Assembly.</li>
<li>Identification of the invoking <code>Method/Class/Assembly</code> is implemented within the <code>Verify_Calling_Method</code> Method (using the <code>StackFrame</code> Class).</li>
</ol>

<hr />

<h2>04 Invoking EXE (03) Using Reflection</h2>
<ol>
<li>Same as '<em>02 Invoking EXE (01) Using Reflection</em>', albeit references '<em>03 EXE - Protected Against Reflection</em>' - instead of '<em>01 EXE - Protected Against Reflection</em>'.</li>
<li>Crashes when executed due to the anti-Reflection measures implemented in '<em>03 EXE - Protected Against Reflection</em>' (due to a <code>MethodAccessException()</code> Exception.).
</ol>

<hr />

<h2>05 Listing Classes And Methods In Assembly Using Reflection</h2>
<ol>
<li>C# Console Application.</li>
<li><code>Main</code> Method is defined in <code>Program.cs</code>.</li>
<li><code>Main</code> Method loads the DLL associated with <em>03 EXE - Protected Against Reflection</em> into memory and dynamically identifies the list of Classes contained within the DLL, as well as the associated Methods (incl. Method Signature).</li>
</ol>
<ul>
<li>The use of Reflection to examine the content of an Assembly - as shown in this case - cannot be prevented; however the execution of Methods via Reflection can be prevented using the technique(s) shown previously in '<em>03 EXE - Protected Against Reflection</em>'.</li>
<li>Note that such functionality is also supported by off the shelf tools such as <a href="https://www.dependencywalker.com/">Dependency Walker</a>.</li>
</ul>

<hr />

<h2>06 EXE - Protected Against Reflection Using Attributes</h2>

<ol>
<li>Same as '<em>01 EXE - No Protection Against Reflection</em>', albeit the <code>[assembly: DisablePrivateReflection]</code> Attribute has been manually added to <code>AssemblyInfo.cs</code> to defend all Classes contained within the Assembly against Reflection.</li>
</ol>

<hr />

<h2>07 Invoking EXE (06) That Prevents Reflection Being Used</h2>

<ol>
<li>Same as '<em>02 Invoking EXE (01) Using Reflection</em>', albeit references '<em>06 EXE - Protected Against Reflection Using Attributes</em>' - instead of '<em>01 EXE - Protected Against Reflection</em>'.</li>
<li>Crashes when executed due to the anti-Reflection measures implemented in '<em>06 EXE - Protected Against Reflection Using Attributes</em>' (due to a <code>MethodAccessException()</code> Exception.).
</ol>
