﻿using System;
using System.Collections.Generic;

/*

struct ContentView : View {
    @State private var password: String = ""

    var body: some View {
        VStack {
            SecureField("Enter a password", text: $password)
            Text("You entered: \(password)")
        }
    }
}

*/
namespace Comet.Samples
{
    public class SecureFieldSample1 : View
    {
        readonly State<string> password = new State<string>("");

        [Body]
        View body() => new VStack()
        {
            new SecureField(password, "Enter a password"),
            new Text(password)
        }.FillHorizontal();
    }
}
