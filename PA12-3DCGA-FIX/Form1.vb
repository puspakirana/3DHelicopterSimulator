Public Class Form1

    Dim bmp As Bitmap
    Dim grp As Graphics

    Public Stack As New Stack

    Public Vt(3, 3), St(3, 3) As Double

    Public mtx As TMatrix = New TMatrix

    Public world, heli1, heli2 As New TElmt3DObject

    'helicopter 1
    Public base1, base2, foot1, foot2, foot3, foot4, body, rotorConn, mainRotor, LTail, UTail,
           HRotor, VRotor1, VRotor2 As TElmt3DObject

    'helicopter 2
    Public baseA, baseB, footA, footB, footC, footD, body2, rotorConn2, mainRotor2, LTail2, Utail2,
           HRotor2, VRotorA, VRotorB As TElmt3DObject

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        bmp = New Bitmap(displayBox.Width, displayBox.Height)
        grp = Graphics.FromImage(bmp)
        grp.Clear(Color.FromArgb(243, 228, 223))

        initializeM()
        initializeNode()
        Draw()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        bmp = New Bitmap(displayBox.Width, displayBox.Height)
        grp = Graphics.FromImage(bmp)
        grp.Clear(Color.FromArgb(243, 228, 223))

        timerStart.Enabled = False

        deg = 0
        deg1 = 0
        turnR = 0
        turnR1 = 0

        upnd = 0
        upnd1 = 0

        fwdb = -15
        fwdb1 = 15
        degZ = 0
        degZ1 = 0

        angleR = 0
        angleR1 = 0
        velo = 0
        velo1 = 0

        initializeNode()
        initializeM()
        Draw()
    End Sub

    'ROTOR START AND STOP-------------------------------------------------------------------------------------------
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        timerStart.Enabled = True
    End Sub

    Dim angleR As Integer = 0
    Dim angleR1 As Integer = 0
    Dim velo As Integer = 0
    Dim velo1 As Integer = 0

    Private Sub timerStart_Tick(sender As Object, e As EventArgs) Handles timerStart.Tick
        If cbHeli1.Checked Then
            velo = tbSpeed.Value
            angleR += velo
            mainRotor.rotate(angleR, "y")
            HRotor.rotate(angleR, "z")
            Draw()
        End If
        If cbHeli2.Checked Then
            velo1 = tbSpeed2.Value
            angleR1 += velo1
            mainRotor2.rotate(angleR1, "y")
            HRotor2.rotate(angleR1, "z")
            Draw()
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        timerStart.Enabled = False
    End Sub

    'WORLD ROTATION------------------------------------------------------------------------------------------------
    Public r As Boolean = False
    Public newX, newY As Integer

    Private Sub displayBox_MouseUp(sender As Object, e As MouseEventArgs) Handles displayBox.MouseUp
        r = False
    End Sub
    Private Sub displayBox_MouseDown(sender As Object, e As MouseEventArgs) Handles displayBox.MouseDown
        r = True
        newX = e.X
        newY = e.Y
    End Sub
    Private Sub displayBox_MouseMove(sender As Object, e As MouseEventArgs) Handles displayBox.MouseMove
        If r Then
            world.rotate(newX - e.X, "y")
            world.rotate(newY - e.Y, "x")
            Draw()
        End If
    End Sub

    'KEYBOARD CONTROL------------------------------------------------------------------------------------------------

    'left right
    Public deg As Integer = 0
    Public deg1 As Integer = 0
    Public turnR As Integer = 0
    Public turnR1 As Integer = 0

    'up down
    Public upnd As Integer = 0
    Public upnd1 As Integer = 0

    'forward backward
    Public fwdb As Integer = -15
    Public fwdb1 As Integer = 15
    Public degZ As Integer = 0
    Public degZ1 As Integer = 0

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If timerStart.Enabled = True Then
            'HELICOPTER TURN RIGHT/LEFT
            If keyData = Keys.Left Then
                If cbHeli1.Checked Then
                    deg = deg + 5
                    heli1.rotate(deg, "y")
                    If turnR < 30 Then
                        turnR = turnR + 1
                        heli1.rotate(turnR, "x")
                    End If
                End If
                If cbHeli2.Checked Then
                    deg1 = deg1 + 5
                    heli2.rotate(deg1, "y")
                    If turnR1 < 30 Then
                        turnR1 = turnR1 + 1
                        heli2.rotate(turnR1, "x")
                    End If
                End If
                Draw()
                Return True
            End If

            If keyData = Keys.Right Then
                If cbHeli1.Checked Then
                    deg = deg - 5
                    heli1.rotate(deg, "y")
                    If turnR > -30 Then
                        turnR = turnR - 1
                        heli1.rotate(turnR, "x")
                    End If
                End If
                If cbHeli2.Checked Then
                    deg1 = deg1 - 5
                    heli2.rotate(deg1, "y")
                    If turnR1 > -30 Then
                        turnR1 = turnR1 - 1
                        heli2.rotate(turnR1, "x")
                    End If
                End If
                Draw()
                Return True
            End If

            'ROTATION IN X AXIS/STABILAZING POSITION
            If keyData = Keys.W Then
                If cbHeli1.Checked Then
                    turnR = turnR + 1
                    heli1.rotate(turnR, "x")
                End If
                If cbHeli2.Checked Then
                    turnR1 = turnR1 + 1
                    heli2.rotate(turnR1, "x")
                End If
                Draw()
                Return True
            End If

            If keyData = Keys.S Then
                If cbHeli1.Checked Then
                    turnR = turnR - 1
                    heli1.rotate(turnR, "x")
                End If
                If cbHeli2.Checked Then
                    turnR1 = turnR1 - 1
                    heli2.rotate(turnR1, "x")
                End If
                Draw()
                Return True
            End If

            'HELICOPTER MOVE UP/DOWN
            If keyData = Keys.Up Then
                If cbHeli1.Checked Then
                    upnd = upnd + 1
                    heli1.translate(upnd, "y")
                End If
                If cbHeli2.Checked Then
                    upnd1 = upnd1 + 1
                    heli2.translate(upnd1, "y")
                End If
                Draw()
                Return True
            End If

            If keyData = Keys.Down Then
                If cbHeli1.Checked Then
                    upnd = upnd - 1
                    heli1.translate(upnd, "y")
                End If
                If cbHeli2.Checked Then
                    upnd1 = upnd1 - 1
                    heli2.translate(upnd1, "y")
                End If
                Draw()
                Return True
            End If

            'FORWARD AND BACKWARD
            If keyData = Keys.D Then
                If cbHeli1.Checked Then
                    If degZ > -10 Then
                        degZ = degZ - 1
                        heli1.rotate(degZ, "z")
                    End If
                    fwdb = fwdb + 1
                    If deg = 0 Then
                        heli1.translate(fwdb, "x")
                    Else
                        heli1.turn(fwdb, "x")
                    End If
                End If
                If cbHeli2.Checked Then
                    If degZ1 > -10 Then
                        degZ1 = degZ1 - 1
                        heli2.rotate(degZ1, "z")
                    End If
                    fwdb1 = fwdb1 + 1
                    If deg1 = 0 Then
                        heli2.translate(fwdb1, "x")
                    Else
                        heli2.turn(fwdb1, "x")
                    End If
                End If
                Draw()
                Return True
            End If

            If keyData = Keys.A Then
                If cbHeli1.Checked Then
                    If degZ < 10 Then
                        degZ = degZ + 1
                        heli1.rotate(degZ, "z")
                    End If
                    fwdb = fwdb - 1
                    If deg = 0 Then
                        heli1.translate(fwdb, "x")
                    Else
                        heli1.turn(fwdb, "x")
                    End If
                End If
                If cbHeli2.Checked Then
                    If degZ1 < 10 Then
                        degZ1 = degZ1 + 1
                        heli2.rotate(degZ1, "z")
                    End If
                    fwdb1 = fwdb1 - 1
                    If deg1 = 0 Then
                        heli2.translate(fwdb1, "x")
                    Else
                        heli2.turn(fwdb1, "x")
                    End If
                End If
                Draw()
                Return True
            End If

            'ROTATION IN Z AXIS/STABILAZING POSITION
            If keyData = Keys.E Then
                If cbHeli1.Checked Then
                    degZ = degZ + 1
                    heli1.rotate(degZ, "z")
                End If
                If cbHeli2.Checked Then
                    degZ1 = degZ1 + 1
                    heli2.rotate(degZ1, "z")
                End If
            End If

            If keyData = Keys.Q Then
                If cbHeli1.Checked Then
                    degZ = degZ - 1
                    heli1.rotate(degZ, "z")
                End If
                If cbHeli2.Checked Then
                    degZ1 = degZ1 - 1
                    heli2.rotate(degZ1, "z")
                End If
            End If

        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    'DRAWING OBJECT TO SCREEN---------------------------------------------------------------------------------------------
    Sub Draw()
        grp.Clear(Color.FromArgb(243, 228, 223))

        Dim tempMtx(3, 3) As Double
        tempMtx = mtx.matrixMultiplication(Vt, St)

        Stack.Push(tempMtx)

        Process(world)

    End Sub

    'PROCESS ELMT 3D OBJECT------------------------------------------------------------------------------------------------
    Sub Process(E As TElmt3DObject)
        Dim T(3, 3) As Double

        While Not IsNothing(E)
            T = mtx.matrixMultiplication(E.transform, Stack.Peek())
            Stack.Push(T)

            Process(E.child)

            If Not IsNothing(E.obj) Then

                Dim trans(,) As Double
                trans = Stack.Pop()

                Dim vtx(7) As Tpoint
                Dim pt1, pt2 As Point

                For i = 0 To vtx.Length - 1
                    vtx(i) = mtx.pointMatrixMultiplication(E.obj.vertices(i), trans)
                    'vtx(i) = mtx.pointMatrixMultiplication(vtx(i), St)
                Next

                For i = 0 To 11
                    pt1.X = vtx(E.obj.edges(i).p1).x / vtx(E.obj.edges(i).p1).w
                    pt1.Y = vtx(E.obj.edges(i).p1).y / vtx(E.obj.edges(i).p1).w
                    pt2.X = vtx(E.obj.edges(i).p2).x / vtx(E.obj.edges(i).p2).w
                    pt2.Y = vtx(E.obj.edges(i).p2).y / vtx(E.obj.edges(i).p2).w

                    If i <= 3 Then
                        grp.DrawLine(Pens.Red, pt1, pt2)
                    Else
                        grp.DrawLine(Pens.Black, pt1, pt2)
                    End If
                Next

            Else
                Stack.Pop()
            End If

            E = E.nxt

        End While

        displayBox.Image = bmp

    End Sub

    'INITIALIZATION 3D OBJECT------------------------------------------------------------------------------------------------
    Sub initializeNode()

        world = New TElmt3DObject
        world.create(0, 0, 0)
        'world.obj = New T3DObject(-12, -12, -12, 12, 12, 12)


        'HELICOPTER 1

        heli1 = New TElmt3DObject
        heli1.create(0, 0, 0)
        world.child = heli1

        base1 = New TElmt3DObject
        base1.create(0, 0, 0)
        base1.obj = New T3DObject(-5, -1, -1, 6, 1, 1)
        heli1.child = base1

        base2 = New TElmt3DObject
        base2.create(0, 0, -6)
        base2.obj = New T3DObject(-5, -1, -1, 6, 1, 1)
        base1.nxt = base2

        foot1 = New TElmt3DObject
        foot1.create(-4, 1, -0.5)
        foot1.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        base1.child = foot1


        foot2 = New TElmt3DObject
        foot2.create(3, 1, -0.5)
        foot2.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        foot1.nxt = foot2


        foot3 = New TElmt3DObject
        foot3.create(-4, 1, -0.5)
        foot3.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        base2.child = foot3


        foot4 = New TElmt3DObject
        foot4.create(3, 1, -0.5)
        foot4.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        foot3.nxt = foot4


        body = New TElmt3DObject
        body.create(0, 1, -6)
        body.obj = New T3DObject(0, 0, 0, 9, 5, 7)
        foot1.child = body


        LTail = New TElmt3DObject
        LTail.create(-5, 2, 2.5)
        LTail.obj = New T3DObject(0, 0, 0, 5, 1, 2)
        body.child = LTail


        UTail = New TElmt3DObject
        UTail.create(0, 1, 0)
        UTail.obj = New T3DObject(0, 0, 0, 1, 2, 2)
        LTail.child = UTail


        HRotor = New TElmt3DObject
        HRotor.create(0.5, 1, 2.15)
        HRotor.obj = New T3DObject(-1, -0.15, -0.15, 1, 0.15, 0.15)
        UTail.child = HRotor
        HRotor.rotate(45, "z")

        VRotor1 = New TElmt3DObject
        VRotor1.create(-0.15, 0.15, -0.15)
        VRotor1.obj = New T3DObject(0, 0, 0, 0.3, 1, 0.3)
        HRotor.child = VRotor1

        VRotor2 = New TElmt3DObject
        VRotor2.create(-0.15, -1.15, -0.15)
        VRotor2.obj = New T3DObject(0, 0, 0, 0.3, 1, 0.3)
        VRotor1.nxt = VRotor2


        rotorConn = New TElmt3DObject
        rotorConn.create(4, 5, 3)
        rotorConn.obj = New T3DObject(0, 0, 0, 1, 1, 1)
        LTail.nxt = rotorConn


        mainRotor = New TElmt3DObject
        mainRotor.create(0, 1.5, 0.5)
        mainRotor.obj = New T3DObject(-5, -0.5, -1, 6, 0.5, 1)
        rotorConn.child = mainRotor

        'HELICOPTER 2
        heli2 = New TElmt3DObject
        heli2.create(0, 0, 0)
        heli1.nxt = heli2

        baseA = New TElmt3DObject
        baseA.create(0, 0, 0)
        baseA.obj = New T3DObject(-5, -1, -1, 6, 1, 1)
        heli2.child = baseA

        baseB = New TElmt3DObject
        baseB.create(0, 0, -6)
        baseB.obj = New T3DObject(-5, -1, -1, 6, 1, 1)
        baseA.nxt = baseB

        footA = New TElmt3DObject
        footA.create(-4, 1, -0.5)
        footA.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        baseA.child = footA


        footB = New TElmt3DObject
        footB.create(3, 1, -0.5)
        footB.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        footA.nxt = footB

        footC = New TElmt3DObject
        footC.create(-4, 1, -0.5)
        footC.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        baseB.child = footC


        footD = New TElmt3DObject
        footD.create(3, 1, -0.5)
        footD.obj = New T3DObject(0, 0, 0, 2, 1, 1)
        footC.nxt = footD


        body2 = New TElmt3DObject
        body2.create(0, 1, -6)
        body2.obj = New T3DObject(0, 0, 0, 9, 5, 7)
        footA.child = body2


        LTail2 = New TElmt3DObject
        LTail2.create(-5, 2, 2.5)
        LTail2.obj = New T3DObject(0, 0, 0, 5, 1, 2)
        body2.child = LTail2


        Utail2 = New TElmt3DObject
        Utail2.create(0, 1, 0)
        Utail2.obj = New T3DObject(0, 0, 0, 1, 2, 2)
        LTail2.child = Utail2


        HRotor2 = New TElmt3DObject
        HRotor2.create(0.5, 1, 2.5)
        HRotor2.obj = New T3DObject(-1, -0.15, -0.15, 1, 0.15, 0.15)
        Utail2.child = HRotor2
        HRotor2.rotate(45, "z")

        VRotorA = New TElmt3DObject
        VRotorA.create(-0.15, 0.15, -0.15)
        VRotorA.obj = New T3DObject(0, 0, 0, 0.3, 1, 0.3)
        HRotor2.child = VRotorA

        VRotorB = New TElmt3DObject
        VRotorB.create(-0.15, -1.15, -0.15)
        VRotorB.obj = New T3DObject(0, 0, 0, 0.3, 1, 0.3)
        VRotorA.nxt = VRotorB


        rotorConn2 = New TElmt3DObject
        rotorConn2.create(4, 5, 3)
        rotorConn2.obj = New T3DObject(0, 0, 0, 1, 1, 1)
        LTail2.nxt = rotorConn2


        mainRotor2 = New TElmt3DObject
        mainRotor2.create(0, 1.5, 0.5)
        mainRotor2.obj = New T3DObject(-5, -0.5, -1, 6, 0.5, 1)
        rotorConn2.child = mainRotor2

        heli2.translate(15, "x")
        heli1.translate(-15, "x")

    End Sub

    'INITIALIZATION MATRIX VT, ST--------------------------------------------------------------------------------------------
    Sub initializeM()
        Dim Pr1(3, 3), Pr2(3, 3), St1(3, 3), St2(3, 3) As Double

        Pr1 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, -0.025},
            {0, 0, 0, 1}
        }

        Pr2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        Vt = mtx.matrixMultiplication(Pr1, Pr2)

        St1 = New Double(3, 3) {
            {10, 0, 0, 0},  'right
            {0, -10, 0, 0}, 'below
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        St2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {400, 400, 0, 1} 'translation to x and y
        }

        St = mtx.matrixMultiplication(St1, St2)
    End Sub


    'POINT------------------------------------------------------------------------------------------------
    Public Class Tpoint
        Public x, y, z, w As Double

        Public Sub New(x As Double, y As Double, z As Double, w As Double)
            Me.x = x
            Me.y = y
            Me.z = z
            Me.w = w
        End Sub
    End Class

    'EDGE------------------------------------------------------------------------------------------------
    Public Class TEdge
        Public p1, p2 As Integer
        Sub New(p1 As Integer, p2 As Integer)
            Me.p1 = p1
            Me.p2 = p2
        End Sub
    End Class

    '3D OBJECT------------------------------------------------------------------------------------------------
    Public Class T3DObject
        Public edges As List(Of TEdge) = New List(Of TEdge)
        Public vertices As List(Of Tpoint) = New List(Of Tpoint)

        Sub New(xmin As Double, ymin As Double, zmin As Double, xmax As Double, ymax As Double, zmax As Double)

            vertices.Add(New Tpoint(xmin, ymax, zmax, 1))
            vertices.Add(New Tpoint(xmax, ymax, zmax, 1))

            vertices.Add(New Tpoint(xmax, ymin, zmax, 1))
            vertices.Add(New Tpoint(xmin, ymin, zmax, 1))

            vertices.Add(New Tpoint(xmin, ymax, zmin, 1))
            vertices.Add(New Tpoint(xmax, ymax, zmin, 1))

            vertices.Add(New Tpoint(xmax, ymin, zmin, 1))
            vertices.Add(New Tpoint(xmin, ymin, zmin, 1))


            edges.Add(New TEdge(0, 1))
            edges.Add(New TEdge(1, 2))
            edges.Add(New TEdge(2, 3))
            edges.Add(New TEdge(3, 0))
            edges.Add(New TEdge(0, 4))
            edges.Add(New TEdge(1, 5))
            edges.Add(New TEdge(2, 6))
            edges.Add(New TEdge(3, 7))
            edges.Add(New TEdge(4, 5))
            edges.Add(New TEdge(5, 6))
            edges.Add(New TEdge(6, 7))
            edges.Add(New TEdge(7, 4))
        End Sub
    End Class

    'ELEMENT 3D OBJECT------------------------------------------------------------------------------------------------
    Public Class TElmt3DObject
        Public T As TMatrix = New TMatrix

        Public obj As T3DObject
        Public child As TElmt3DObject
        Public nxt As TElmt3DObject
        Public transform(3, 3) As Double

        Public thetaX, thetaY, thetaZ As Double
        Public translateX, translateY, translateZ As Double

        Public Sub create(x As Double, y As Double, z As Double)
            thetaX = 0
            thetaY = 0
            thetaZ = 0

            translateX = 0
            translateY = 0
            translateZ = 0

            transform = T.initMatrix(x, y, z)
        End Sub

        'rotation object
        Public Sub rotate(angle As Double, axis As Char)
            Dim R(3, 3) As Double
            Dim deg, sinT, cosT As Double

            If axis = "x" Then
                deg = angle - thetaX
                thetaX = angle
            ElseIf axis = "y" Then
                deg = angle - thetaY
                thetaY = angle
            ElseIf axis = "z" Then
                deg = angle - thetaZ
                thetaZ = angle
            End If

            deg = Math.PI * (deg / 180)
            sinT = Math.Sin(deg)
            cosT = Math.Cos(deg)

            If (axis = "x") Then
                R = New Double(3, 3) {
                    {1, 0, 0, 0},
                    {0, cosT, sinT, 0},
                    {0, -sinT, cosT, 0},
                    {0, 0, 0, 1}
                }
            ElseIf (axis = "y") Then
                R = New Double(3, 3) {
                    {cosT, 0, -sinT, 0},
                    {0, 1, 0, 0},
                    {sinT, 0, cosT, 0},
                    {0, 0, 0, 1}
                }
            ElseIf (axis = "z") Then
                R = New Double(3, 3) {
                    {cosT, sinT, 0, 0},
                    {-sinT, cosT, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1}
                }
            End If

            transform = T.matrixMultiplication(R, transform)
        End Sub

        'translate object
        Public Sub translate(newPnt As Double, axis As Char)
            Dim current As Double

            If axis = "x" Then
                current = newPnt - translateX
                translateX = newPnt
            ElseIf axis = "y" Then
                current = newPnt - translateY
                translateY = newPnt
            ElseIf axis = "z" Then
                current = newPnt - translateZ
                translateZ = newPnt
            End If

            Dim Tr(3, 3) As Double

            If axis = "x" Then
                Tr = T.initMatrix(current, 0, 0)
            ElseIf axis = "y" Then
                Tr = T.initMatrix(0, current, 0)
            ElseIf axis = "z" Then
                Tr = T.initMatrix(0, 0, current)
            End If

            transform = T.matrixMultiplication(transform, Tr)

        End Sub

        'turn helicopter
        Public Sub turn(newPnt As Double, axis As Char)
            Dim current As Double

            If axis = "x" Then
                current = newPnt - translateX
                translateX = newPnt
            ElseIf axis = "y" Then
                current = newPnt - translateY
                translateY = newPnt
            ElseIf axis = "z" Then
                current = newPnt - translateZ
                translateZ = newPnt
            End If

            Dim Tr(3, 3) As Double

            If axis = "x" Then
                Tr = T.initMatrix(current, 0, 0)
            ElseIf axis = "y" Then
                Tr = T.initMatrix(0, current, 0)
            ElseIf axis = "z" Then
                Tr = T.initMatrix(0, 0, current)
            End If

            transform = T.matrixMultiplication(Tr, transform)
        End Sub

    End Class

    'MATRIX------------------------------------------------------------------------------------------------
    Public Class TMatrix

        'matrix multiplication
        Function matrixMultiplication(M1(,) As Double, M2(,) As Double) As Double(,)
            Dim temp(3, 3) As Double
            For i = 0 To 3
                temp(i, 0) = M1(i, 0) * M2(0, 0) + M1(i, 1) * M2(1, 0) + M1(i, 2) * M2(2, 0) + M1(i, 3) * M2(3, 0)
                temp(i, 1) = M1(i, 0) * M2(0, 1) + M1(i, 1) * M2(1, 1) + M1(i, 2) * M2(2, 1) + M1(i, 3) * M2(3, 1)
                temp(i, 2) = M1(i, 0) * M2(0, 2) + M1(i, 1) * M2(1, 2) + M1(i, 2) * M2(2, 2) + M1(i, 3) * M2(3, 2)
                temp(i, 3) = M1(i, 0) * M2(0, 3) + M1(i, 1) * M2(1, 3) + M1(i, 2) * M2(2, 3) + M1(i, 3) * M2(3, 3)
            Next
            Return temp
        End Function

        'point matrix multiplication
        Function pointMatrixMultiplication(Pnt As Tpoint, M(,) As Double) As Tpoint
            Return New Tpoint(Pnt.x * M(0, 0) + Pnt.y * M(1, 0) + Pnt.z * M(2, 0) + Pnt.w * M(3, 0),
                              Pnt.x * M(0, 1) + Pnt.y * M(1, 1) + Pnt.z * M(2, 1) + Pnt.w * M(3, 1),
                              Pnt.x * M(0, 2) + Pnt.y * M(1, 2) + Pnt.z * M(2, 2) + Pnt.w * M(3, 2),
                              Pnt.x * M(0, 3) + Pnt.y * M(1, 3) + Pnt.z * M(2, 3) + Pnt.w * M(3, 3))
        End Function

        Overloads Function initMatrix() As Double(,)
            Return New Double(3, 3) {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
                }
        End Function

        Overloads Function initMatrix(x As Double, y As Double, z As Double)
            Return New Double(3, 3) {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {x, y, z, 1}
                }
        End Function

    End Class

End Class
