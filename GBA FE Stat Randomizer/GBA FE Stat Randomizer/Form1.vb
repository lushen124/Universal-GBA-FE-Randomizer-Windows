Public Class Form1

    Enum RecruitmentType
        RecruitmentTypeNormal
        RecruitmentTypeReverse
        RecruitmentTypeRandom
    End Enum

    Enum EnemyBuffType
        BuffTypeSetConstant
        BuffTypeSetMaximum
        BuffTypeSetMinimum
    End Enum

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseButton.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private type As Utilities.GameType

    Private hasAlreadyRandomized As Boolean

    Private shouldRandomizeGrowths As Boolean
    Private growthsVariance As Integer
    Private shouldForceMinimumGrowth As Boolean
    Private shouldWeightHPGrowths As Boolean

    Private shouldRandomizeBases As Boolean
    Private baseVariance As Integer
    Private shouldRandomizeCON As Boolean
    Private CONVariance As Integer
    Private minimumCON As Integer
    Private shouldRandomizeMOV As Boolean
    Private minimumMOV As Integer
    Private maximumMOV As Integer

    Private shouldRandomizeAffinity As Boolean

    Private shouldRandomizeClasses As Boolean
    Private randomLords As Boolean
    Private randomThieves As Boolean
    Private randomBosses As Boolean
    Private uniqueClasses As Boolean

    Private shouldRandomizeItems As Boolean
    Private mightVariance As Integer
    Private minimumMight As Integer
    Private hitVariance As Integer
    Private minimumHit As Integer
    Private criticalVariance As Integer
    Private minimumCritical As Integer
    Private weightVariance As Integer
    Private minimumWeight As Integer
    Private maximumWeight As Integer
    Private durabilityVariance As Integer
    Private minimumDurability As Integer
    Private randomTraits As Boolean

    Private buffEnemies As Boolean
    Private buffAmount As Integer
    Private buffType As EnemyBuffType
    Private buffBosses As Boolean

    Private recruitment As RecruitmentType

    Private applyTutorialKiller As Boolean ' FE7 only.


    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        FilenameTextBox.Text = OpenFileDialog1.FileName

        Dim inputFile = IO.File.OpenRead(OpenFileDialog1.FileName)

        inputFile.Seek(&HAC, IO.SeekOrigin.Begin)

        Dim gameCode As ArrayList = Utilities.ReadWordIntoArrayListFromFile(inputFile)

        'Known Game Codes
        ' FE6 - AFEJ (JP)
        ' FE7 - AE7E (NA)
        ' FE8 - BE8E (NA)

        type = Utilities.GameType.GameTypeUnknown

        If gameCode.Item(0).Equals(Asc("A")) And gameCode.Item(1).Equals(Asc("F")) And gameCode.Item(2).Equals(Asc("E")) And gameCode.Item(3).Equals(Asc("J")) Then type = Utilities.GameType.GameTypeFE6
        If gameCode.Item(0).Equals(Asc("A")) And gameCode.Item(1).Equals(Asc("E")) And gameCode.Item(2).Equals(Asc("7")) And gameCode.Item(3).Equals(Asc("E")) Then type = Utilities.GameType.GameTypeFE7
        If gameCode.Item(0).Equals(Asc("B")) And gameCode.Item(1).Equals(Asc("E")) And gameCode.Item(2).Equals(Asc("8")) And gameCode.Item(3).Equals(Asc("E")) Then type = Utilities.GameType.GameTypeFE8

        If type = Utilities.GameType.GameTypeFE6 Then
            GameDetectionLabel.Text = "Game Detected: Fire Emblem 6"
            RandomizeButton.Enabled = True
            GameSpecificCheckbox.Hide()
            applyTutorialKiller = False
        ElseIf type = Utilities.GameType.GameTypeFE7 Then
            GameDetectionLabel.Text = "Game Detected: Fire Emblem 7"
            RandomizeButton.Enabled = True

            ' Check if the Tutorial Killer Patch is already in effect. (Just use any byte)
            inputFile.Seek(&HC9A214, IO.SeekOrigin.Begin)
            Dim alreadyPatched As Boolean = inputFile.ReadByte() = &H5
            GameSpecificCheckbox.Text = "Apply Arch's Tutorial Slayer"
            GameSpecificCheckbox.Show()
            GameSpecificCheckbox.Enabled = False
            GameSpecificCheckbox.Checked = Not alreadyPatched
            applyTutorialKiller = Not alreadyPatched
        ElseIf type = Utilities.GameType.GameTypeFE8 Then
            GameDetectionLabel.Text = "Game Detected: Fire Emblem 8"
            RandomizeButton.Enabled = True
            GameSpecificCheckbox.Hide()
            applyTutorialKiller = False
        Else
            GameDetectionLabel.Text = "Unknown Game (Code: " + Convert.ToChar(gameCode.Item(0)) + Convert.ToChar(gameCode.Item(1)) + Convert.ToChar(gameCode.Item(2)) + Convert.ToChar(gameCode.Item(3)) + ")"
            RandomizeButton.Enabled = False
            applyTutorialKiller = False
            GameSpecificCheckbox.Hide()
        End If

        inputFile.Seek(-4, IO.SeekOrigin.End)

        Dim suffix As Byte() = {0, 0, 0, 0}
        inputFile.Read(suffix, 0, 4)

        Dim signature As Byte() = System.Text.Encoding.ASCII.GetBytes("GFR1")

        hasAlreadyRandomized = suffix(0) = signature(0) And suffix(1) = signature(1) And suffix(2) = signature(2) And suffix(3) = signature(3)

        inputFile.Close()

        If type <> Utilities.GameType.GameTypeUnknown Then
            reenableAllControls()

            Dim hasSeenNotice As Boolean = My.Settings.HasSeenBetaNotice
            If Not hasSeenNotice Then
                MsgBox("Thanks for testing out the Universal GBA FE Randomizer!" + vbCrLf + vbCrLf _
                           & "This is an early build of the app that is still missing several features, but I figure it should be good enough to test with so that we catch any other issues I'm not aware of sooner rather than later." + vbCrLf + vbCrLf _
                           & "Controls that are disabled are likely not yet implemented. Most notably, Random classes has only been implemented with FE6. FE7 and FE8 should soon follow." + vbCrLf + vbCrLf _
                           & "Please report any issues you encounter when using this app. You can share a randomized instance of a game using NUPS to create ups patches with your randomized info. Please do so to report issues." + vbCrLf + vbCrLf _
                           & "Thanks again!" + vbCrLf + vbCrLf _
                           & "- /u/OtakuReborn", MsgBoxStyle.Information, "Notice")

                My.Settings.HasSeenBetaNotice = True
                My.Settings.Save()
            End If

        End If

    End Sub

    Private Sub RandomizeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeButton.Click

        If hasAlreadyRandomized Then
            Dim result As MsgBoxResult = MsgBox("This game seems to have been randomized before. It is recommended that a fresh version of the game be used for randomization." + vbCrLf + vbCrLf _
                   & "If you wish to continue, know that any further changes will be applied on top of an already randomized game. This means the initial randomized parameters will be used as the base for the new randomized version." + vbCrLf + vbCrLf _
                   & "If you see items gain more and more effects or item stats becoming more and more extreme, you now know why." + vbCrLf + vbCrLf _
                   & "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Warning")

            If result = MsgBoxResult.No Then Return
        End If

        disableAllControls()

        Dim characterList As ArrayList = New ArrayList()
        Dim characterLookup As Hashtable = New Hashtable()
        Dim characterTableOffset As Integer = 0
        Dim numberOfCharacters As Integer = 0
        Dim characterEntrySize As Integer = 0

        Dim classList As ArrayList = New ArrayList()
        Dim classLookup As Hashtable = New Hashtable()
        Dim classTableOffset As Integer = 0
        Dim numberOfClasses As Integer = 0
        Dim classEntrySize As Integer = 0

        Dim itemList As ArrayList = New ArrayList()
        Dim itemLookup As Hashtable = New Hashtable()
        Dim itemTableOffset As Integer = 0
        Dim numberOfItems As Integer = 0
        Dim itemEntrySize As Integer = 0

        Dim repointedCharacterTable = False
        Dim repointedClassTable = False
        Dim repointedItemTable = False

        Dim chapterUnitData As ArrayList = New ArrayList()

        Dim lordCharacters As ArrayList = New ArrayList()
        Dim thiefCharacters As ArrayList = New ArrayList()
        Dim bossCharacters As ArrayList = New ArrayList()
        Dim exemptCharacters As ArrayList = New ArrayList()

        Dim quoteManager As QuoteManager = Nothing
        Dim supportManager As SupportManager = Nothing

        Dim spellAssociationManager As SpellAssociationManager = Nothing

        Dim promotionManager As PromotionManager = Nothing

        Dim fileReader = IO.File.OpenRead(OpenFileDialog1.FileName)

        If type = Utilities.GameType.GameTypeFE6 Then
            fileReader.Seek(FE6GameData.PointerToCharacterTableOffset, IO.SeekOrigin.Begin)
            characterTableOffset = Utilities.ReadWord(fileReader, True)
            If characterTableOffset <> FE6GameData.DefaultCharacterTableOffset Then
                MsgBox("Character Table Offset has been updated. Character Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all characters may be randomized if the table is expanded." + vbCrLf _
                       & "Determining which units are enemies and allies may also be inaccurate.", MsgBoxStyle.Information, "Notice")
                repointedCharacterTable = True
            End If
            numberOfCharacters = FE6GameData.CharacterCount
            characterEntrySize = FE6GameData.CharacterEntrySize

            fileReader.Seek(FE6GameData.PointerToClassTableOffset, IO.SeekOrigin.Begin)
            classTableOffset = Utilities.ReadWord(fileReader, True)
            If classTableOffset <> FE6GameData.DefaultClassTableOffset Then
                MsgBox("Class Table Offset has been updated. Class Table may have been repointed." + vbCrLf _
                       & "If the number of classes has changed, only the classes up to the original amount" + vbCrLf _
                       & "will be updated and used.", MsgBoxStyle.Information, "Notice")
                repointedClassTable = True
            End If
            numberOfClasses = FE6GameData.ClassCount
            classEntrySize = FE6GameData.ClassEntrySize

            fileReader.Seek(FE6GameData.PointerToItemTableOffset, IO.SeekOrigin.Begin)
            itemTableOffset = Utilities.ReadWord(fileReader, True)
            If itemTableOffset <> FE6GameData.DefaultItemTableOffset Then
                MsgBox("Item Table Offset has been updated. Item Table may have been repointed." + vbCrLf _
                       & "If the number of items has changed, only the items up to the original amount" + vbCrLf _
                       & "will be updated and used.", MsgBoxStyle.Information, "Notice")
                repointedItemTable = True
            End If
            numberOfItems = FE6GameData.ItemCount
            itemEntrySize = FE6GameData.ItemEntrySize

            Dim chapterPointers As Array = System.Enum.GetValues(GetType(FE6GameData.ChapterUnitReference))
            Dim chapterUnitCounts As ArrayList = FE6GameData.UnitsInEachChapter

            For i As Integer = 0 To chapterPointers.Length - 1
                Dim pointer = chapterPointers(i)
                Dim unitCount = chapterUnitCounts.Item(i)
                Dim unitList As ArrayList = New ArrayList()
                fileReader.Seek(pointer, IO.SeekOrigin.Begin)
                For j As Integer = 1 To unitCount
                    Dim unit As FEChapterUnit = New FEChapterUnit
                    unit.initializeWithBytesFromOffset(fileReader, fileReader.Position, FE6GameData.ChapterUnitEntrySize, type)
                    unitList.Add(unit)
                Next
                chapterUnitData.Add(unitList)
            Next

            lordCharacters = FE6GameData.lordCharacterIDs()
            thiefCharacters = FE6GameData.thiefCharacterIDs()
            bossCharacters = FE6GameData.bossCharacterIDs()
            exemptCharacters = FE6GameData.exemptCharacterIDs()

            quoteManager = New QuoteManager(Utilities.GameType.GameTypeFE6, fileReader)
            supportManager = New SupportManager(Utilities.GameType.GameTypeFE6, fileReader)

            promotionManager = New PromotionManager(Utilities.GameType.GameTypeFE6, fileReader)
        ElseIf type = Utilities.GameType.GameTypeFE7 Then

            fileReader.Seek(FE7GameData.PointerToCharacterTableOffset, IO.SeekOrigin.Begin)
            characterTableOffset = Utilities.ReadWord(fileReader, True)
            If characterTableOffset <> FE7GameData.DefaultCharacterTableOffset Then
                MsgBox("Character Table Offset has been updated. Character Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all characters may be randomized if the table is expanded." + vbCrLf _
                       & "Determining which units are enemies and allies may also be inaccurate.", MsgBoxStyle.Information, "Notice")
                repointedCharacterTable = True
            End If
            numberOfCharacters = FE7GameData.CharacterCount
            characterEntrySize = FE7GameData.CharacterEntrySize

            fileReader.Seek(FE7GameData.PointerToClassTableOffset, IO.SeekOrigin.Begin)
            classTableOffset = Utilities.ReadWord(fileReader, True)
            If classTableOffset <> FE7GameData.DefaultClassTableOffset Then
                MsgBox("Class Table Offset has been updated. Class Table may have been repointed." + vbCrLf _
                       & "If the number of classes has changed, only the classes up to the original amount" + vbCrLf _
                       & "will be updated and used.", MsgBoxStyle.Information, "Notice")
                repointedClassTable = True
            End If
            numberOfClasses = FE7GameData.ClassCount
            classEntrySize = FE7GameData.ClassEntrySize

            fileReader.Seek(FE7GameData.PointerToItemTableOffset, IO.SeekOrigin.Begin)
            itemTableOffset = Utilities.ReadWord(fileReader, True)
            If itemTableOffset <> FE7GameData.DefaultItemTableOffset Then
                MsgBox("Item Table Offset has been updated. Item Table may have been repointed." + vbCrLf _
                       & "If the number of items has changed, only the items up to the original amount" + vbCrLf _
                       & "will be updated and used.", MsgBoxStyle.Information, "Notice")
                repointedItemTable = True
            End If
            numberOfItems = FE7GameData.ItemCount
            itemEntrySize = FE7GameData.ItemEntrySize

            Dim chapterPointers As Array = System.Enum.GetValues(GetType(FE7GameData.ChapterUnitReference))
            Dim chapterUnitCounts As ArrayList = FE7GameData.UnitsInEachChapter

            For i As Integer = 0 To chapterPointers.Length - 1
                Dim pointer = chapterPointers(i)
                Dim unitCount = chapterUnitCounts.Item(i)
                Dim unitList As ArrayList = New ArrayList()
                fileReader.Seek(pointer, IO.SeekOrigin.Begin)
                For j As Integer = 1 To unitCount
                    Dim unit As FEChapterUnit = New FEChapterUnit
                    unit.initializeWithBytesFromOffset(fileReader, fileReader.Position, FE7GameData.ChapterUnitEntrySize, type)
                    unitList.Add(unit)
                Next
                chapterUnitData.Add(unitList)
            Next

            lordCharacters = FE7GameData.lordCharacterIDs()
            thiefCharacters = FE7GameData.thiefCharacterIDs()
            bossCharacters = FE7GameData.bossCharacterIDs()
            exemptCharacters = FE7GameData.exemptCharacterIDs()

            quoteManager = New QuoteManager(Utilities.GameType.GameTypeFE7, fileReader)
            supportManager = New SupportManager(Utilities.GameType.GameTypeFE7, fileReader)

            spellAssociationManager = New SpellAssociationManager(Utilities.GameType.GameTypeFE7, fileReader)

            promotionManager = New PromotionManager(Utilities.GameType.GameTypeFE7, fileReader)
        ElseIf type = Utilities.GameType.GameTypeFE8 Then

            fileReader.Seek(FE8GameData.PointerToCharacterTableOffset, IO.SeekOrigin.Begin)
            characterTableOffset = Utilities.ReadWord(fileReader, True)
            If characterTableOffset <> FE8GameData.DefaultCharacterTableOffset Then
                MsgBox("Character Table Offset has been updated. Character Table may have been repointed." + vbCrLf _
                       & "If this is a hacked game, not all characters may be randomized if the table is expanded." + vbCrLf _
                       & "Determining which units are enemies and allies may also be inaccurate.", MsgBoxStyle.Information, "Notice")
                repointedCharacterTable = True
            End If
            numberOfCharacters = FE8GameData.CharacterCount
            characterEntrySize = FE8GameData.CharacterEntrySize

            fileReader.Seek(FE8GameData.PointerToClassTableOffset, IO.SeekOrigin.Begin)
            classTableOffset = Utilities.ReadWord(fileReader, True)
            If classTableOffset <> FE8GameData.DefaultClassTableOffset Then
                MsgBox("Class Table Offset has been updated. Class Table may have been repointed." + vbCrLf _
                       & "If the number of classes has changed, only the classes up to the original amount" + vbCrLf _
                       & "will be updated and used.", MsgBoxStyle.Information, "Notice")
                repointedClassTable = True
            End If
            numberOfClasses = FE8GameData.ClassCount
            classEntrySize = FE8GameData.ClassEntrySize

            fileReader.Seek(FE8GameData.PointerToItemTableOffset, IO.SeekOrigin.Begin)
            itemTableOffset = Utilities.ReadWord(fileReader, True)
            If itemTableOffset <> FE8GameData.DefaultItemTableOffset Then
                MsgBox("Item Table Offset has been updated. Item Table may have been repointed." + vbCrLf _
                       & "If the number of items has changed, only the items up to the original amount" + vbCrLf _
                       & "will be updated and used.", MsgBoxStyle.Information, "Notice")
                repointedItemTable = True
            End If
            numberOfItems = FE8GameData.ItemCount
            itemEntrySize = FE8GameData.ItemEntrySize

            Dim chapterPointers As Array = System.Enum.GetValues(GetType(FE8GameData.ChapterUnitReference))
            Dim chapterUnitCounts As ArrayList = FE8GameData.UnitsInEachChapter

            For i As Integer = 0 To chapterPointers.Length - 1
                Dim pointer = chapterPointers(i)
                Dim unitCount = chapterUnitCounts.Item(i)
                Dim unitList As ArrayList = New ArrayList()
                fileReader.Seek(pointer, IO.SeekOrigin.Begin)
                For j As Integer = 1 To unitCount
                    Dim unit As FEChapterUnit = New FEChapterUnit
                    unit.initializeWithBytesFromOffset(fileReader, fileReader.Position, FE8GameData.ChapterUnitEntrySize, type)
                    unitList.Add(unit)
                Next
                chapterUnitData.Add(unitList)
            Next

            lordCharacters = FE8GameData.lordCharacterIDs()
            thiefCharacters = FE8GameData.thiefCharacterIDs()
            bossCharacters = FE8GameData.bossCharacterIDs()
            exemptCharacters = FE8GameData.exemptCharacterIDs()

            quoteManager = New QuoteManager(Utilities.GameType.GameTypeFE8, fileReader)
            supportManager = New SupportManager(Utilities.GameType.GameTypeFE8, fileReader)

            promotionManager = New PromotionManager(Utilities.GameType.GameTypeFE8, fileReader)

            MsgBox("You seem to be randomizing FE8. Note that depending on the randomizing results, the tutorial (Easy Mode) may no longer be completable." + vbCrLf + vbCrLf _
                   & "It is recommended that you only play this on the Normal Or Difficult Modes to ensure functionality.", MsgBoxStyle.Information, "Notice")
        End If

        fileReader.Seek(characterTableOffset, IO.SeekOrigin.Begin)

        For index As Integer = 1 To numberOfCharacters
            Dim currentCharacter As FECharacter = New FECharacter

            currentCharacter.initializeWithBytesFromOffset(fileReader, fileReader.Position, characterEntrySize, type)

            characterList.Add(currentCharacter)
            Utilities.setObjectForKey(characterLookup, currentCharacter, currentCharacter.characterId)
        Next

        fileReader.Seek(classTableOffset, IO.SeekOrigin.Begin)

        For index As Integer = 1 To numberOfClasses
            Dim currentClass As FEClass = New FEClass

            currentClass.initializeWithBytesFromOffset(fileReader, fileReader.Position, classEntrySize, type)

            classList.Add(currentClass)
            Utilities.setObjectForKey(classLookup, currentClass, currentClass.classId)
        Next

        fileReader.Seek(itemTableOffset, IO.SeekOrigin.Begin)

        For index As Integer = 1 To numberOfItems
            Dim currentItem As FEItem = New FEItem

            currentItem.initializeWithBytesFromOffset(fileReader, fileReader.Position, itemEntrySize, type)

            itemList.Add(currentItem)
            Utilities.setObjectForKey(itemLookup, currentItem, currentItem.weaponID)
        Next

        fileReader.Close()

        ' For easier lookup later, also organize items by their type and rank.
        Dim itemByType As Hashtable = New Hashtable()
        Dim itemByRank As Hashtable = New Hashtable()

        ' FE8 only. Magical monster weapons are classified as Dark instead of monster weapon.
        ' That's fine, but we need to set their ability 2 as a monster weapon.
        Dim monsterWeaponIDs = FE8GameData.magicalMonsterWeaponIDs()

        For Each itemEntry As FEItem In itemList
            ' The list starts with a terminal 0 item, skip that one.
            If itemEntry.weaponID = 0 Then Continue For

            ' Be on the lookout for any blacklisted items.
            If type = Utilities.GameType.GameTypeFE6 And FE6GameData.isBlacklisted(itemEntry.weaponID) Then Continue For
            If type = Utilities.GameType.GameTypeFE7 And FE7GameData.isBlacklisted(itemEntry.weaponID) Then Continue For
            If type = Utilities.GameType.GameTypeFE8 And FE8GameData.isBlacklisted(itemEntry.weaponID) Then Continue For

            ' For FE8 update the monster weapons so that they can only be used by monsters.
            ' This mostly applies to the magic ones, which are classified as dark weapons, but have
            ' no rank (and actually aren't marked as monster weapons).
            ' The monster classes that use monster weapons have their flag set, so they'll be use it
            ' even if it is changed to a monster weapon. Also give it an E rank so
            ' that only magic monsters can use it.
            If type = Utilities.GameType.GameTypeFE8 Then
                If monsterWeaponIDs.Contains(System.Enum.ToObject(GetType(FE8GameData.ItemList), itemEntry.weaponID)) Then
                    itemEntry.weaponAbility2 = itemEntry.weaponAbility2 Or FEItem.Ability2.Ability2MonsterWeaponDragonLock
                    itemEntry.rank = FE8GameData.WeaponRank.WeaponRankE
                End If
            End If

            Dim weaponType As FEItem.WeaponType = itemEntry.type
            Dim weaponList As ArrayList = itemByType.Item(weaponType)
            If IsNothing(weaponList) Then
                weaponList = New ArrayList()
                itemByType.Add(weaponType, weaponList)
            End If
            weaponList.Add(itemEntry.weaponID)

            Dim weaponRank = itemEntry.rank
            Dim rankList As ArrayList = itemByRank.Item(weaponRank)
            If IsNothing(rankList) Then
                rankList = New ArrayList()
                itemByRank.Add(weaponRank, rankList)
            End If
            rankList.Add(itemEntry.weaponID)
        Next

        Dim rng As Random = New Random

        If recruitment <> RecruitmentType.RecruitmentTypeNormal Then
StartOver:
            Dim usedCharacters As ArrayList = New ArrayList()

            ' Since events reference characters by ID, the easiest way to do this
            ' is to modify what character is mapped to which ID.
            Dim playableCharactersList As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.playableCharacterIDs(),
                                                          IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.playableCharacterIDs(False),
                                                              FE8GameData.playableCharacterIDs()))
            Dim exemptCharacterList As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.exemptCharacterIDs(),
                                                       IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.exemptCharacterIDs(),
                                                           FE8GameData.exemptCharacterIDs()))
            ' We can't copy it, so we're going to just rebuild the list.
            Dim newCharacterList As ArrayList = New ArrayList()
            For i As Integer = 0 To characterList.Count - 1
                ' Grab the original character in this spot.
                Dim character As FECharacter = characterList.Item(i)
                Dim characterIDObject = IIf(type = Utilities.GameType.GameTypeFE6, System.Enum.ToObject(GetType(FE6GameData.CharacterList), character.characterId),
                                            IIf(type = Utilities.GameType.GameTypeFE7, System.Enum.ToObject(GetType(FE7GameData.CharacterList), character.characterId),
                                                System.Enum.ToObject(GetType(FE8GameData.CharacterList), character.characterId)))
                ' Make sure he's somebody we want to move.
                If playableCharactersList.Contains(characterIDObject) And Not exemptCharacterList.Contains(characterIDObject) Then
                    Dim characterClass As FEClass = classLookup.Item(character.classId)
                    Dim replacingLordCharacter As Boolean = characterClass.ability2 And FEClass.ClassAbility2.Lord
                    ' Determine his replacement.
                    Dim replacement As Byte
                    If recruitment = RecruitmentType.RecruitmentTypeReverse Then
                        replacement = IIf(type = Utilities.GameType.GameTypeFE6, Convert.ToByte(FE6GameData.reversedRecruitmentMappingForCharacter(characterIDObject)),
                                          IIf(type = Utilities.GameType.GameTypeFE7, Convert.ToByte(FE7GameData.reversedRecruitmentMappingForCharacter(characterIDObject)),
                                              Convert.ToByte(FE8GameData.reversedRecruitmentMappingForCharacter(characterIDObject))))
                    Else
                        Dim shouldNotDemoteList As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.shouldNotDemoteCharacterIDs(),
                                                                   IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.shouldNotDemoteCharacterIDs(),
                                                                       FE8GameData.shouldNotDemoteCharacterIDs()))
                        Dim canNotPromoteList As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.canNotPromoteCharacterIDs(),
                                                                 IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.canNotPromoteCharacterIDs(),
                                                                     FE8GameData.canNotPromoteCharacterIDs()))
                        Dim targetClassIsPromoted As Boolean = characterClass.ability2 And FEClass.ClassAbility2.Promoted
                        Dim characterListType As Type = IIf(type = Utilities.GameType.GameTypeFE6, GetType(FE6GameData.CharacterList),
                                                            IIf(type = Utilities.GameType.GameTypeFE7, GetType(FE7GameData.CharacterList),
                                                                GetType(FE8GameData.CharacterList)))
                        Dim counter = 0
                        Do
                            ' We're probably in case where we can't fulfill all of the conditions.
                            ' Just start over in that case. We haven't written anything final to
                            ' the data yet (since we've been working off of a copy of the character
                            ' and the newCharacterList)
                            If counter = 1000 Then
                                Console.WriteLine("Reached a dead-end in assigning replacement characters. Starting over...")
                                GoTo StartOver
                            End If
                            counter += 1
                            replacement = playableCharactersList.Item(rng.Next(playableCharactersList.Count))
                        Loop While usedCharacters.Contains(replacement) Or
                            ((Not targetClassIsPromoted) And shouldNotDemoteList.Contains(System.Enum.ToObject(characterListType, replacement))) Or
                            (replacingLordCharacter And canNotPromoteList.Contains(System.Enum.ToObject(characterListType, replacement))) Or
                            (targetClassIsPromoted And canNotPromoteList.Contains(System.Enum.ToObject(characterListType, replacement))) Or
                            exemptCharacterList.Contains(System.Enum.ToObject(characterListType, replacement))
                        usedCharacters.Add(replacement)
                    End If

                    If Not IsNothing(replacement) Then
                        ' Find the character and drop him in.
                        Dim replacementCharacter As FECharacter = characterLookup.Item(replacement)
                        If Not IsNothing(replacementCharacter) Then
                            replacementCharacter = replacementCharacter.Copy()
                            newCharacterList.Add(replacementCharacter)
                            ' Update the replacement's character ID to the original character's ID.
                            If Not IsNothing(quoteManager) Then
                                quoteManager.updateCharacterIDs(replacementCharacter.characterId, character.characterId)
                                quoteManager.transferTriggerIDs(character.characterId, replacementCharacter.characterId)
                            End If
                            ' Also update supports
                            If Not IsNothing(supportManager) Then
                                supportManager.updateCharacterIDs(replacementCharacter.characterId, character.characterId)
                            End If
                            replacementCharacter.characterId = character.characterId
                            If replacingLordCharacter Then
                                replacementCharacter.ability2 = replacementCharacter.ability2 Or FECharacter.ClassAbility2.Lord
                            End If
                            ' Go ahead and change his class if it needs changing and delevel (or level him) as necessary
                            Dim originalLevel As Integer = replacementCharacter.level
                            Dim targetLevel As Integer = character.level
                            Dim originalClass As FEClass = classLookup.Item(replacementCharacter.classId)
                            Dim newClassID As Byte
                            If recruitment = RecruitmentType.RecruitmentTypeReverse Then
                                newClassID = IIf(type = Utilities.GameType.GameTypeFE6, Convert.ToByte(FE6GameData.reversedRecruitmentClassMappingForCharacter(replacement)),
                                                 IIf(type = Utilities.GameType.GameTypeFE7, Convert.ToByte(FE7GameData.reversedRecruitmentClassMappingForCharacter(replacement)),
                                                     Convert.ToByte(FE8GameData.reversedRecruitmentClassMappingForCharacter(replacement))))
                            Else
                                ' Assume no change first.
                                newClassID = replacementCharacter.classId
                                Dim shouldBePromoted As Boolean = characterClass.ability2 And FEClass.ClassAbility2.Promoted
                                Dim isPromoted As Boolean = originalClass.ability2 And FEClass.ClassAbility2.Promoted
                                If type = Utilities.GameType.GameTypeFE8 Then
                                    ' FE8 is a bit different since we have to deal with class branches.
                                    Dim oldClassIDObject As FE8GameData.ClassList = System.Enum.ToObject(GetType(FE8GameData.ClassList), replacementCharacter.classId)
                                    If shouldBePromoted And Not isPromoted Then
                                        Dim newClassIDObject As FE8GameData.ClassList = FE8GameData.promotedClassForUnpromotedClass(oldClassIDObject)
                                        Dim alternativeClassIDObject As FE8GameData.ClassList = FE8GameData.alternatePromotionForPromotedClass(newClassIDObject)

                                        If newClassIDObject <> FE8GameData.ClassList.None And alternativeClassIDObject <> FE8GameData.ClassList.None Then
                                            ' He's got two choices, pick one.
                                            If rng.Next(0, 2) = 0 Then
                                                newClassID = Convert.ToByte(newClassIDObject)
                                            Else
                                                newClassID = Convert.ToByte(alternativeClassIDObject)
                                            End If
                                        ElseIf newClassIDObject <> FE8GameData.ClassList.None Then
                                            newClassID = Convert.ToByte(newClassIDObject)
                                        Else
                                            newClassID = replacementCharacter.classId
                                        End If
                                    ElseIf Not shouldBePromoted And isPromoted Then
                                        Dim possibleDemotions As ArrayList = FE8GameData.possibleDemotionsForPromotedClass(oldClassIDObject)
                                        If possibleDemotions.Count > 0 Then
                                            Dim newClassIDObject As FE8GameData.ClassList = possibleDemotions.Item(rng.Next(0, possibleDemotions.Count))
                                            If newClassIDObject <> FE8GameData.ClassList.None Then
                                                newClassID = Convert.ToByte(newClassIDObject)
                                            End If
                                        Else
                                            newClassID = replacementCharacter.classId
                                        End If
                                    End If

                                    If newClassID = Convert.ToByte(FE8GameData.ClassList.None) Then
                                        newClassID = replacementCharacter.classId
                                    End If
                                Else

                                    If shouldBePromoted And Not isPromoted Then
                                        newClassID = IIf(type = Utilities.GameType.GameTypeFE6, Convert.ToByte(FE6GameData.promotedClassForUnpromotedClass(System.Enum.ToObject(GetType(FE6GameData.ClassList), replacementCharacter.classId))),
                                                         IIf(type = Utilities.GameType.GameTypeFE7, Convert.ToByte(FE7GameData.promotedClassForUnpromotedClass(System.Enum.ToObject(GetType(FE7GameData.ClassList), replacementCharacter.classId))), Nothing))
                                    ElseIf Not shouldBePromoted And isPromoted Then
                                        newClassID = IIf(type = Utilities.GameType.GameTypeFE6, Convert.ToByte(FE6GameData.unpromotedClassForPromotedClass(System.Enum.ToObject(GetType(FE6GameData.ClassList), replacementCharacter.classId))),
                                                         IIf(type = Utilities.GameType.GameTypeFE7, Convert.ToByte(FE7GameData.unpromotedClassForPromotedClass(System.Enum.ToObject(GetType(FE7GameData.ClassList), replacementCharacter.classId))), Nothing))
                                    End If
                                    If newClassID = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.ClassList.None,
                                                        IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.ClassList.None, Nothing)) Then newClassID = replacementCharacter.classId
                                End If

                            End If

                            If Not IsNothing(newClassID) Then
                                Dim replacementClass As FEClass = classLookup.Item(newClassID)
                                If Not IsNothing(replacementClass) Then
                                    ' Assume promotion at level 10 for calculating levels.
                                    If originalClass.ability2 And FEClass.ClassAbility2.Promoted Then originalLevel += 9
                                    If replacementClass.ability2 And FEClass.ClassAbility2.Promoted Then targetLevel += 9
                                    If originalLevel > targetLevel Then
                                        replacementCharacter.levelWithClass(replacementClass, originalLevel - targetLevel, True, rng)
                                    ElseIf targetLevel > originalLevel Then
                                        replacementCharacter.levelWithClass(replacementClass, targetLevel - originalLevel, False, rng)
                                    End If
                                    replacementCharacter.level = IIf(replacementClass.ability2 And FEClass.ClassAbility2.Promoted, targetLevel - 9, targetLevel)
                                    replacementCharacter.classId = newClassID
                                End If
                            End If
                        Else
                            ' If we didn't get a replacement, add the old character back into his spot (no change)
                            newCharacterList.Add(character)
                        End If
                    Else
                        ' The character has no replacement. (no change)
                        newCharacterList.Add(character)
                    End If
                Else
                    ' If he's not a playable character, add him as is (no change)
                    newCharacterList.Add(character)
                End If
            Next

            ' Now that newCharacterList has the updated list, replace the old one with it.
            characterList = newCharacterList
            ' Update the lookup for consistency.
            characterLookup.Clear()
            For Each character As FECharacter In characterList
                Utilities.setObjectForKey(characterLookup, character, character.characterId)
            Next
        End If

        For Each character As FECharacter In characterList
            If shouldRandomizeBases Then
                character.randomizeBases(baseVariance, rng)
            End If

            If shouldRandomizeGrowths Then
                character.randomizeGrowths(growthsVariance, shouldForceMinimumGrowth, shouldWeightHPGrowths, rng)
            End If

            If shouldRandomizeCON Then
                character.randomizeCON(minimumCON, CONVariance, classLookup.Item(character.classId), rng)
            End If

            If shouldRandomizeAffinity Then
                character.randomizeAffinity(rng)
            End If
        Next

        If shouldRandomizeMOV Then
            For Each charClass As FEClass In classList
                charClass.randomizeMOV(minimumMOV, maximumMOV, rng)
            Next
        End If

        If shouldRandomizeItems Then
            For Each item As FEItem In itemList
                If item.isWeapon() Then
                    item.randomizeItemDurability(durabilityVariance, minimumDurability, rng)
                    item.randomizeItemMight(mightVariance, minimumMight, rng)
                    item.randomizeItemHit(hitVariance, minimumHit, rng)
                    item.randomizeItemWeight(weightVariance, minimumWeight, maximumWeight, rng)
                    item.randomizeItemCritical(criticalVariance, minimumCritical, rng)
                    If randomTraits Then
                        item.assignRandomEffect(rng, type)
                        If item.weaponAbility1 And FEItem.Ability1.Ability1MagicDamage And Not IsNothing(spellAssociationManager) Then spellAssociationManager.assignRandomSpellAnimationToWeaponWithID(item.weaponID, rng)
                    End If
                End If
            Next
        End If

        If shouldRandomizeClasses Or recruitment <> RecruitmentType.RecruitmentTypeNormal Then
            ' Cache results as they happen so that we maintain consistency.
            Dim targetClasses As Hashtable = New Hashtable()
            Dim originalClasses As Hashtable = New Hashtable()

            Dim classType As Type = IIf(type = Utilities.GameType.GameTypeFE6, GetType(FE6GameData.ClassList),
                                        IIf(type = Utilities.GameType.GameTypeFE7, GetType(FE7GameData.ClassList),
                                            GetType(FE8GameData.ClassList)))
            Dim characterType As Type = IIf(type = Utilities.GameType.GameTypeFE6, GetType(FE6GameData.CharacterList),
                                            IIf(type = Utilities.GameType.GameTypeFE7, GetType(FE7GameData.CharacterList),
                                                GetType(FE8GameData.CharacterList)))

            Dim importantCharacterIDs = New ArrayList(System.Enum.GetValues(characterType))

            Dim weaponLevelIncreaseChance As Integer = 0

            ' Go through each chapter.
            For Each chapterUnits As ArrayList In chapterUnitData
                ' Let's start with 5% per chapter (Gaidens and splits included)
                weaponLevelIncreaseChance += 8
                ' For every unit found in the chapter data
                For Each unit As FEChapterUnit In chapterUnits

                    ' Skip units with id = 0 (The game uses these as dividers between groups of units)
                    If unit.characterId = 0 Then
                        Continue For
                    End If
                    ' Make sure their classID is valid, otherwise don't touch it.
                    If type = Utilities.GameType.GameTypeFE6 Then
                        If Not FE6GameData.isValidClass(unit.classId) And unit.levelAlliance = &H0 Then
                            Continue For
                        End If
                    ElseIf type = Utilities.GameType.GameTypeFE7 Then
                        If Not FE7GameData.isValidClass(unit.classId) And unit.levelAlliance = &H0 Then
                            Continue For
                        End If
                    ElseIf type = Utilities.GameType.GameTypeFE8 Then
                        If Not FE8GameData.isValidClass(unit.classId) And unit.levelAlliance = &H0 Then
                            Continue For
                        End If
                    End If

                    ' If it's a real character (i.e. not a random mook) then see if we already had something for
                    ' him or her.
                    Dim characterIDObject As Object = System.Enum.ToObject(characterType, unit.characterId)
                    If importantCharacterIDs.Contains(characterIDObject) Then
                        ' If he's one of the units we shouldn't touch, then skip it.
                        ' Don't skip if we're not randomizing though, because we still want to
                        ' take advantage of the random starting items.
                        If shouldRandomizeClasses Then
                            If Not randomLords And lordCharacters.Contains(characterIDObject) Then
                                Continue For
                            ElseIf Not randomThieves And thiefCharacters.Contains(characterIDObject) Then
                                Continue For
                            ElseIf Not randomBosses And bossCharacters.Contains(characterIDObject) Then
                                Continue For
                            ElseIf exemptCharacters.Contains(characterIDObject) Then
                                Continue For
                            End If
                        Else
                            ' Never touch bosses if we're not randomizing classes (or blacklisted for that matter)
                            If bossCharacters.Contains(characterIDObject) Then
                                Continue For
                            ElseIf exemptCharacters.Contains(characterIDObject) Then
                                Continue For
                            End If
                        End If

                        ' If we got this far, he/she's getting randomized
                        ' Grab a random class from the allowed classes. Each game
                        ' will know what valid classes are possible.

                        ' First, let the unit knows that he has changed so that
                        ' he will write. Otherwise, to avoid issues, we don't write the ones that haven't changed.
                        unit.hasChanged = True

                        Dim newClassId As Byte
                        ' Keep track of whether this character was a Lord character, because whatever
                        ' his or her new class is also needs to have lord abilities (like Seize)
                        Dim wasLord As Boolean = False
                        ' Keep track of thieves too. If they're randomized, we need to give them
                        ' some keys.
                        Dim wasThief As Boolean = False
                        Dim currentCharacter As FECharacter = characterLookup.Item(unit.characterId)

                        ' Check for boss characters.
                        Dim isBoss As Boolean = bossCharacters.Contains(characterIDObject)

                        ' FE6 stores this in the character object.
                        Dim oldClass As FEClass = classLookup.Item(currentCharacter.classId)
                        If originalClasses.ContainsKey(unit.characterId) Then oldClass = classLookup.Item(originalClasses.Item(unit.characterId))
                        wasLord = oldClass.isLord
                        wasThief = oldClass.isThief
                        ' If he already had one assigned, use that.
                        If targetClasses.ContainsKey(characterIDObject) Then
                            newClassId = targetClasses.Item(characterIDObject)
                        Else
                            Utilities.setObjectForKey(originalClasses, oldClass.classId, unit.characterId)
                            If shouldRandomizeClasses Then
                                If type = Utilities.GameType.GameTypeFE6 Then
                                    newClassId = FE6GameData.randomClassFromOriginalClass(oldClass.classId,
                                                                                          randomLords,
                                                                                          randomThieves,
                                                                                          uniqueClasses,
                                                                                          lordCharacters.Contains(characterIDObject),
                                                                                          wasLord Or isBoss,
                                                                                          rng)
                                ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                    newClassId = FE7GameData.randomClassFromOriginalClass(oldClass.classId,
                                                                                          randomLords,
                                                                                          randomThieves,
                                                                                          uniqueClasses,
                                                                                          lordCharacters.Contains(characterIDObject),
                                                                                          wasLord Or isBoss,
                                                                                          rng)
                                Else
                                    newClassId = FE8GameData.randomClassFromOriginalClass(oldClass.classId,
                                                                                          randomLords,
                                                                                          randomThieves,
                                                                                          uniqueClasses,
                                                                                          lordCharacters.Contains(characterIDObject),
                                                                                          wasLord Or isBoss,
                                                                                          FE8GameData.traineeCharacterIDs.Contains(characterIDObject), rng)
                                End If
                            Else
                                newClassId = currentCharacter.classId
                            End If
                        End If

                        ' For FE7, some characters have linked classes, so changing it in one place should change it in the other place.
                        ' This may not work properly for modified recruitment.
                        If type = Utilities.GameType.GameTypeFE7 Then
                            Dim linkedIDs As ArrayList = FE7GameData.linkedCharacterIDsToCharacterID(currentCharacter.characterId)
                            For Each linkedId As FE7GameData.CharacterList In linkedIDs
                                If targetClasses.ContainsKey(linkedId) Then
                                    newClassId = targetClasses.Item(linkedId)
                                    Exit For
                                End If
                            Next
                        ElseIf type = Utilities.GameType.GameTypeFE8 Then
                            ' FE8 does this too.
                            Dim linkedIDs As ArrayList = FE8GameData.linkedCharacterIDsToCharacterID(currentCharacter.characterId)
                            For Each linkedId As FE8GameData.CharacterList In linkedIDs
                                If targetClasses.ContainsKey(linkedId) Then
                                    newClassId = targetClasses.Item(linkedId)
                                    Exit For
                                End If
                            Next
                        End If

                        Dim newClass As FEClass = classLookup.Item(newClassId)

                        ' If we're randomly assigning classes (or just re-assigning classes in general)
                        ' make sure the scripts don't blow up if they're told to move somewhere.
                        ' Tell the class to normalize its movement costs so that units can pass through all tiles
                        ' while moving as part of a script.
                        If Not IsNothing(newClass) Then
                            newClass.normalizeImpassableTiles(type)
                        End If

                        ' If the old class was a lord, then apply the lord status on the 
                        ' character (not the class!)
                        If wasLord Then
                            currentCharacter.ability2 = currentCharacter.ability2 Or FECharacter.ClassAbility2.Lord
                        End If

                        ' Update the character's class in the object.
                        currentCharacter.classId = newClass.classId

                        ' Make sure their weapon levels are consistent with their new class.
                        currentCharacter.swordLevel = newClass.swordLevel
                        currentCharacter.spearLevel = newClass.spearLevel
                        currentCharacter.axeLevel = newClass.axeLevel
                        currentCharacter.bowLevel = newClass.bowLevel
                        currentCharacter.staffLevel = newClass.staffLevel
                        currentCharacter.animaLevel = newClass.animaLevel
                        currentCharacter.darkLevel = newClass.darkLevel
                        currentCharacter.lightLevel = newClass.lightLevel

                        ' Add a chance to increase their weapon ranks depending
                        ' on how late they join.
                        currentCharacter.increaseWeaponRanksWithPercentChance(weaponLevelIncreaseChance, type, rng)

                        ' Make sure their class has valid stats.
                        currentCharacter.validate(newClass, minimumCON, type)

                        If type = Utilities.GameType.GameTypeFE7 Then
                            ' For FE7, some characters have custom sprites that override their existing sprites.
                            ' If they promote, then we don't really care, and if their class doesn't change
                            ' that's also ok.
                            ' But if they change to a completely different class, then we need to unset the 
                            ' custom sprite (since it will no longer reflect their class).
                            If oldClass.classId <> newClass.classId And
                                Convert.ToByte(FE7GameData.promotedClassForUnpromotedClass(System.Enum.ToObject(classType, oldClass.classId))) <> newClass.classId Then
                                currentCharacter.shouldResetCustomSpriteToDefault = True
                            End If
                        End If

                        ' Cache the result of this character's class.
                        Utilities.setObjectForKey(targetClasses, newClass.classId, characterIDObject)

                        ' Remember to update their class in the chapter data.
                        ' Be wary of some other classes. FE6 likes to use characters
                        ' for NPCs temporarily, so don't mess with those.
                        If type = Utilities.GameType.GameTypeFE6 Then
                            If Not FE6GameData.isValidClass(unit.classId) And unit.levelAlliance = &H0 Then
                                Console.WriteLine("Skipping invalid classID: " + unit.classId)
                            Else
                                unit.classId = newClass.classId
                            End If
                        ElseIf type = Utilities.GameType.GameTypeFE7 Then
                            If Not FE7GameData.isValidClass(unit.classId) And unit.levelAlliance = &H0 Then
                                Console.WriteLine("Skipping invalid classID: " + unit.classId)
                            Else
                                unit.classId = newClass.classId
                            End If
                        ElseIf type = Utilities.GameType.GameTypeFE8 Then
                            If Not FE8GameData.isValidClass(unit.classId) And unit.levelAlliance = &H0 Then
                                Console.WriteLine("Skipping invalid classID: " + unit.classId)
                            Else
                                unit.classId = newClass.classId
                            End If
                        Else
                            unit.classId = newClass.classId
                        End If

                        ' Validate their inventory too.
                        ' Check each item and make sure weapons they start with are usable.
                        ' Replace ones that aren't with ones that are.
                        Dim validatedInventory As ArrayList = New ArrayList()

                        Dim hasLegendaryWeapon As Boolean = False

                        ' Ensure everybody who can attack actually has a weapon.
                        ' Also ensure all healers actually have heal staves.
                        Dim attackerHasUsableWeapon As Boolean = False
                        Dim healerHasHealingStaff As Boolean = False

                        ' For FE7 check for legendary-ness
                        If type = Utilities.GameType.GameTypeFE7 Then
                            ' Note: this only works for bosses. Normal characters may have swapped IDs, so may not work with them.
                            Dim isLegendary As Boolean = FE7GameData.shouldSpawnWithLegendaryWeapon(unit.characterId)
                            If isLegendary Then
                                Dim legendaryWeapon As FEItem = itemLookup(Convert.ToByte(FE7GameData.legendaryWeaponForClass(newClass.classId)))
                                If Not IsNothing(legendaryWeapon) Then
                                    hasLegendaryWeapon = True
                                    validatedInventory.Add(FE7GameData.ItemList.Elixir)
                                    validatedInventory.Add(legendaryWeapon.weaponID)
                                    validatedInventory.Add(0)
                                    validatedInventory.Add(0)
                                    If legendaryWeapon.type = FEItem.WeaponType.WeaponTypeAnima Then
                                        currentCharacter.animaLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeAxe Then
                                        currentCharacter.axeLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeBow Then
                                        currentCharacter.bowLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeDark Then
                                        currentCharacter.darkLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeLight Then
                                        currentCharacter.lightLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeSpear Then
                                        currentCharacter.spearLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeStaff Then
                                        currentCharacter.staffLevel = FE7GameData.WeaponRank.WeaponRankS
                                    ElseIf legendaryWeapon.type = FEItem.WeaponType.WeaponTypeSword Then
                                        currentCharacter.swordLevel = FE7GameData.WeaponRank.WeaponRankS
                                    End If
                                End If
                            End If
                        End If
                        Dim validWeapons As ArrayList = New ArrayList()

                        If hasLegendaryWeapon = False Then
                            If currentCharacter.swordLevel > 0 Then
                                Dim validSwords As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeSword)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.swordLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validSwords, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.spearLevel > 0 Then
                                Dim validSpears As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeSpear)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.spearLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validSpears, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.axeLevel > 0 Then
                                Dim validAxes As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeAxe)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.axeLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validAxes, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.bowLevel > 0 Then
                                Dim validBows As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeBow)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.bowLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validBows, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.animaLevel > 0 Then
                                Dim validAnima As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeAnima)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.animaLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validAnima, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.lightLevel > 0 Then
                                Dim validLight As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeLight)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.lightLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validLight, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.darkLevel > 0 Then
                                Dim validDark As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeDark)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.darkLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validDark, weaponsByRank))
                                    End If
                                Next
                            End If
                            If currentCharacter.staffLevel > 0 Then
                                Dim validStaves As ArrayList = itemByType.Item(FEItem.WeaponType.WeaponTypeStaff)
                                For Each key In itemByRank.Keys
                                    If key <= currentCharacter.staffLevel Then
                                        Dim weaponsByRank As ArrayList = itemByRank(key)
                                        validWeapons = Utilities.arrayUnion(validWeapons, Utilities.arrayIntersect(validStaves, weaponsByRank))
                                    End If
                                Next
                            End If

                            Dim hasUniqueItemAlready As Boolean = False

                            If unit.item1Id <> 0 Then
                                Dim item1 As FEItem = itemLookup.Item(unit.item1Id)
                                If IsNothing(item1) Then
                                    ' Not an item we know of (probably not of the default set)
                                    ' Just leave it as is.
                                    validatedInventory.Add(unit.item1Id)
                                ElseIf item1.isWeapon() Or item1.type = FEItem.WeaponType.WeaponTypeStaff Then
                                    ' It's a weapon we know. Check if the character can still use it.
                                    If Utilities.canCharacterUseWeapon(currentCharacter, item1, newClass) Then
                                        ' If so, leave the weapon in.
                                        validatedInventory.Add(item1.weaponID)
                                        attackerHasUsableWeapon = item1.type <> FEItem.WeaponType.WeaponTypeStaff
                                        healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(item1.weaponID),
                                                                    IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(item1.weaponID),
                                                                        FE8GameData.isHealingStaff(item1.weaponID)))
                                    Else
                                        ' It's a weapon the character can't use. Need
                                        ' to find a suitable replacement.
                                        If validWeapons.Count > 0 Then
                                            Dim newWeapon As FEItem = Nothing
                                            Do While Not Utilities.canCharacterUseWeapon(currentCharacter, newWeapon, newClass)
                                                newWeapon = itemLookup.Item(validWeapons.Item(rng.Next(validWeapons.Count)))
                                            Loop
                                            validatedInventory.Add(newWeapon.weaponID)
                                            attackerHasUsableWeapon = newWeapon.type <> FEItem.WeaponType.WeaponTypeStaff
                                            healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(newWeapon.weaponID),
                                                                        IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(newWeapon.weaponID),
                                                                            FE8GameData.isHealingStaff(item1.weaponID)))
                                        Else
                                            If type = Utilities.GameType.GameTypeFE6 Then
                                                If newClass.classId = FE6GameData.ClassList.Manakete Then
                                                    validatedInventory.Add(FE6GameData.ItemList.FireDragonStone)
                                                    hasUniqueItemAlready = True
                                                ElseIf newClass.classId = FE6GameData.ClassList.Manakete_F Then
                                                    validatedInventory.Add(FE6GameData.ItemList.DivineDragonStone)
                                                    hasUniqueItemAlready = True
                                                Else
                                                    validatedInventory.Add(item1.weaponID)
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                                If newClass.classId = FE7GameData.ClassList.Dancer Or newClass.classId = FE7GameData.ClassList.Bard Then
                                                    validatedInventory.Add(FE7GameData.ItemList.NinisGrace)
                                                    hasUniqueItemAlready = True
                                                Else
                                                    validatedInventory.Add(item1.weaponID)
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE8 Then
                                                If newClass.classId = FE8GameData.ClassList.Manakete_F Then
                                                    validatedInventory.Add(FE8GameData.ItemList.HolyDragonStone)
                                                    hasUniqueItemAlready = True
                                                Else
                                                    validatedInventory.Add(item1.weaponID)
                                                End If
                                            Else
                                                validatedInventory.Add(item1.weaponID)
                                            End If
                                        End If
                                    End If
                                Else
                                    ' It's not a weapon to begin with.
                                    ' Leave it as is.
                                    validatedInventory.Add(item1.weaponID)
                                End If
                            Else
                                validatedInventory.Add(0)
                            End If
                            If unit.item2Id <> 0 Then
                                Dim item2 As FEItem = itemLookup.Item(unit.item2Id)
                                If IsNothing(item2) Then
                                    ' Not an item we know of (probably not of the default set)
                                    ' Just leave it as is.
                                    validatedInventory.Add(unit.item2Id)
                                ElseIf item2.isWeapon() Or item2.type = FEItem.WeaponType.WeaponTypeStaff Then
                                    ' It's a weapon we know. Check if the character can still use it.
                                    If Utilities.canCharacterUseWeapon(currentCharacter, item2, newClass) Then
                                        ' If so, leave the weapon in.
                                        validatedInventory.Add(item2.weaponID)
                                        attackerHasUsableWeapon = item2.type <> FEItem.WeaponType.WeaponTypeStaff
                                        healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(item2.weaponID),
                                                                    IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(item2.weaponID),
                                                                        FE8GameData.isHealingStaff(item2.weaponID)))
                                    Else
                                        ' It's a weapon the character can't use. Need
                                        ' to find a suitable replacement.
                                        If validWeapons.Count > 0 Then
                                            Dim newWeapon As FEItem = Nothing
                                            Do While Not Utilities.canCharacterUseWeapon(currentCharacter, newWeapon, newClass)
                                                newWeapon = itemLookup.Item(validWeapons.Item(rng.Next(validWeapons.Count)))
                                            Loop
                                            validatedInventory.Add(newWeapon.weaponID)
                                            attackerHasUsableWeapon = newWeapon.type <> FEItem.WeaponType.WeaponTypeStaff
                                            healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(newWeapon.weaponID),
                                                                        IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(newWeapon.weaponID),
                                                                            FE8GameData.isHealingStaff(item2.weaponID)))
                                        Else
                                            If type = Utilities.GameType.GameTypeFE6 Then
                                                If hasUniqueItemAlready Then
                                                    validatedInventory.Add(FE6GameData.ItemList.Elixir)
                                                Else
                                                    If newClass.classId = FE6GameData.ClassList.Manakete Then
                                                        validatedInventory.Add(FE6GameData.ItemList.FireDragonStone)
                                                        hasUniqueItemAlready = True
                                                    ElseIf newClass.classId = FE6GameData.ClassList.Manakete_F Then
                                                        validatedInventory.Add(FE6GameData.ItemList.DivineDragonStone)
                                                        hasUniqueItemAlready = True
                                                    Else
                                                        validatedInventory.Add(item2.weaponID)
                                                    End If
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                                If hasUniqueItemAlready Then
                                                    validatedInventory.Add(FE7GameData.ItemList.Elixir)
                                                Else
                                                    If newClass.classId = FE7GameData.ClassList.Dancer Or newClass.classId = FE7GameData.ClassList.Bard Then
                                                        validatedInventory.Add(FE7GameData.ItemList.NinisGrace)
                                                        hasUniqueItemAlready = True
                                                    Else
                                                        validatedInventory.Add(item2.weaponID)
                                                    End If
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE8 Then
                                                If newClass.classId = FE8GameData.ClassList.Manakete_F Then
                                                    validatedInventory.Add(FE8GameData.ItemList.HolyDragonStone)
                                                    hasUniqueItemAlready = True
                                                Else
                                                    validatedInventory.Add(item2.weaponID)
                                                End If
                                            Else
                                                validatedInventory.Add(item2.weaponID)
                                            End If
                                        End If
                                    End If
                                Else
                                    ' It's not a weapon to begin with.
                                    ' Leave it as is.
                                    validatedInventory.Add(item2.weaponID)
                                End If
                            Else
                                validatedInventory.Add(0)
                            End If
                            If unit.item3Id <> 0 Then
                                Dim item3 As FEItem = itemLookup.Item(unit.item3Id)
                                If IsNothing(item3) Then
                                    ' Not an item we know of (probably not of the default set)
                                    ' Just leave it as is.
                                    validatedInventory.Add(unit.item3Id)
                                ElseIf item3.isWeapon() Or item3.type = FEItem.WeaponType.WeaponTypeStaff Then
                                    ' It's a weapon we know. Check if the character can still use it.
                                    If Utilities.canCharacterUseWeapon(currentCharacter, item3, newClass) Then
                                        ' If so, leave the weapon in.
                                        validatedInventory.Add(item3.weaponID)
                                        attackerHasUsableWeapon = item3.type <> FEItem.WeaponType.WeaponTypeStaff
                                        healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(item3.weaponID),
                                                                    IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(item3.weaponID),
                                                                        FE8GameData.isHealingStaff(item3.weaponID)))
                                    Else
                                        ' It's a weapon the character can't use. Need
                                        ' to find a suitable replacement.
                                        If validWeapons.Count > 0 Then
                                            Dim newWeapon As FEItem = Nothing
                                            Do While Not Utilities.canCharacterUseWeapon(currentCharacter, newWeapon, newClass)
                                                newWeapon = itemLookup.Item(validWeapons.Item(rng.Next(validWeapons.Count)))
                                            Loop
                                            validatedInventory.Add(newWeapon.weaponID)
                                            attackerHasUsableWeapon = newWeapon.type <> FEItem.WeaponType.WeaponTypeStaff
                                            healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(newWeapon.weaponID),
                                                                        IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(newWeapon.weaponID),
                                                                            FE8GameData.isHealingStaff(item3.weaponID)))
                                        Else
                                            If type = Utilities.GameType.GameTypeFE6 Then
                                                If hasUniqueItemAlready Then
                                                    validatedInventory.Add(FE6GameData.ItemList.Elixir)
                                                Else
                                                    If newClass.classId = FE6GameData.ClassList.Manakete Then
                                                        validatedInventory.Add(FE6GameData.ItemList.FireDragonStone)
                                                        hasUniqueItemAlready = True
                                                    ElseIf newClass.classId = FE6GameData.ClassList.Manakete_F Then
                                                        validatedInventory.Add(FE6GameData.ItemList.DivineDragonStone)
                                                        hasUniqueItemAlready = True
                                                    Else
                                                        validatedInventory.Add(item3.weaponID)
                                                    End If
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                                If hasUniqueItemAlready Then
                                                    validatedInventory.Add(FE7GameData.ItemList.Elixir)
                                                Else
                                                    If newClass.classId = FE7GameData.ClassList.Dancer Or newClass.classId = FE7GameData.ClassList.Bard Then
                                                        validatedInventory.Add(FE7GameData.ItemList.NinisGrace)
                                                        hasUniqueItemAlready = True
                                                    Else
                                                        validatedInventory.Add(item3.weaponID)
                                                    End If
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE8 Then
                                                If newClass.classId = FE8GameData.ClassList.Manakete_F Then
                                                    validatedInventory.Add(FE8GameData.ItemList.HolyDragonStone)
                                                    hasUniqueItemAlready = True
                                                Else
                                                    validatedInventory.Add(item3.weaponID)
                                                End If
                                            Else
                                                validatedInventory.Add(item3.weaponID)
                                            End If
                                        End If
                                    End If
                                Else
                                    ' It's not a weapon to begin with.
                                    ' Leave it as is.
                                    validatedInventory.Add(item3.weaponID)
                                End If
                            Else
                                validatedInventory.Add(0)
                            End If
                            If unit.item4Id <> 0 Then
                                Dim item4 As FEItem = itemLookup.Item(unit.item4Id)
                                If IsNothing(item4) Then
                                    ' Not an item we know of (probably not of the default set)
                                    ' Just leave it as is.
                                    validatedInventory.Add(unit.item4Id)
                                ElseIf item4.isWeapon() Or item4.type = FEItem.WeaponType.WeaponTypeStaff Then
                                    ' It's a weapon we know. Check if the character can still use it.
                                    If Utilities.canCharacterUseWeapon(currentCharacter, item4, newClass) Then
                                        ' If so, leave the weapon in.
                                        validatedInventory.Add(item4.weaponID)
                                        attackerHasUsableWeapon = item4.type <> FEItem.WeaponType.WeaponTypeStaff
                                        healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(item4.weaponID),
                                                                    IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(item4.weaponID),
                                                                        FE8GameData.isHealingStaff(item4.weaponID)))
                                    Else
                                        ' It's a weapon the character can't use. Need
                                        ' to find a suitable replacement.
                                        If validWeapons.Count > 0 Then
                                            Dim newWeapon As FEItem = Nothing
                                            Do While Not Utilities.canCharacterUseWeapon(currentCharacter, newWeapon, newClass)
                                                newWeapon = itemLookup.Item(validWeapons.Item(rng.Next(validWeapons.Count)))
                                            Loop
                                            validatedInventory.Add(newWeapon.weaponID)
                                            attackerHasUsableWeapon = newWeapon.type <> FEItem.WeaponType.WeaponTypeStaff
                                            healerHasHealingStaff = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.isHealingStaff(newWeapon.weaponID),
                                                                        IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.isHealingStaff(newWeapon.weaponID),
                                                                            FE8GameData.isHealingStaff(item4.weaponID)))
                                        Else
                                            If type = Utilities.GameType.GameTypeFE6 Then
                                                If hasUniqueItemAlready Then
                                                    validatedInventory.Add(FE6GameData.ItemList.Elixir)
                                                Else
                                                    If newClass.classId = FE6GameData.ClassList.Manakete Then
                                                        validatedInventory.Add(FE6GameData.ItemList.FireDragonStone)
                                                        hasUniqueItemAlready = True
                                                    ElseIf newClass.classId = FE6GameData.ClassList.Manakete_F Then
                                                        validatedInventory.Add(FE6GameData.ItemList.DivineDragonStone)
                                                        hasUniqueItemAlready = True
                                                    Else
                                                        validatedInventory.Add(item4.weaponID)
                                                    End If
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                                If hasUniqueItemAlready Then
                                                    validatedInventory.Add(FE7GameData.ItemList.Elixir)
                                                Else
                                                    If newClass.classId = FE7GameData.ClassList.Dancer Or newClass.classId = FE7GameData.ClassList.Bard Then
                                                        validatedInventory.Add(FE7GameData.ItemList.NinisGrace)
                                                        hasUniqueItemAlready = True
                                                    Else
                                                        validatedInventory.Add(item4.weaponID)
                                                    End If
                                                End If
                                            ElseIf type = Utilities.GameType.GameTypeFE8 Then
                                                If newClass.classId = FE8GameData.ClassList.Manakete_F Then
                                                    validatedInventory.Add(FE8GameData.ItemList.HolyDragonStone)
                                                    hasUniqueItemAlready = True
                                                Else
                                                    validatedInventory.Add(item4.weaponID)
                                                End If
                                            Else
                                                validatedInventory.Add(item4.weaponID)
                                            End If
                                        End If
                                    End If
                                Else
                                    ' It's not a weapon to begin with.
                                    ' Leave it as is.
                                    validatedInventory.Add(item4.weaponID)
                                End If
                            Else
                                validatedInventory.Add(0)
                            End If
                        End If


                        ' For thieves (either characters originally thieves or
                        ' characters that are turned into thieves), they have special
                        ' requirements to make sure the game is still completable.
                        ' Old thieves need to have keys to make sure they can perform basic
                        ' thief actions. New thieves get a free set of lockpicks.

                        Dim lockpickItem As Byte = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.ItemList.Lockpick,
                                                               IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.ItemList.Lockpick,
                                                                   FE8GameData.ItemList.Lockpick))

                        If randomThieves Then
                            If wasThief And Not newClass.isThief Then

                                If Not IsNothing(lockpickItem) Then
                                    Dim lockpickIndex As Integer = validatedInventory.IndexOf(lockpickItem)
                                    If lockpickIndex <> -1 Then
                                        validatedInventory.RemoveAt(lockpickIndex)
                                        validatedInventory.Add(0)
                                    End If
                                End If

                                Dim equipment As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.randomizedFromThiefEquipment,
                                                                 IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.randomizedFromThiefEquipment,
                                                                     FE8GameData.randomizedFromThiefEquipment))
                                If Not IsNothing(equipment) Then
                                    For Each item As Byte In equipment
                                        Dim firstEmptySlot As Integer = validatedInventory.IndexOf(0)
                                        If firstEmptySlot = -1 Then
                                            Exit For
                                        End If
                                        validatedInventory.Insert(firstEmptySlot, item)
                                    Next
                                End If

                            ElseIf Not wasThief And newClass.isThief Then
                                Dim equipment As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.randomizedToThiefEquipment,
                                                                 IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.randomizedToThiefEquipment,
                                                                     FE8GameData.randomizedToThiefEquipment))
                                If Not IsNothing(equipment) Then
                                    For Each item As Byte In equipment
                                        Dim firstEmptySlot As Integer = validatedInventory.IndexOf(0)
                                        If firstEmptySlot = -1 Then
                                            Exit For
                                        End If
                                        validatedInventory.Insert(firstEmptySlot, item)
                                    Next
                                End If
                            End If
                        End If

                        If recruitment <> RecruitmentType.RecruitmentTypeNormal Then
                            Dim thiefArray As ArrayList = New ArrayList()
                            If type = Utilities.GameType.GameTypeFE6 Then
                                thiefArray = FE6GameData.thiefCharacterIDs()
                            ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                thiefArray = FE7GameData.thiefCharacterIDs()
                            ElseIf type = Utilities.GameType.GameTypeFE8 Then
                                thiefArray = FE8GameData.thiefCharacterIDs()
                            End If
                            wasThief = thiefArray.Contains(System.Enum.ToObject(characterType, characterIDObject))
                            If newClass.isThief Then
                                Dim equipment As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.randomizedToThiefEquipment,
                                                                 IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.randomizedToThiefEquipment,
                                                                     FE8GameData.randomizedToThiefEquipment))
                                If Not IsNothing(equipment) Then
                                    For Each item As Byte In equipment
                                        Dim firstEmptySlot As Integer = validatedInventory.IndexOf(0)
                                        If firstEmptySlot = -1 Then
                                            Exit For
                                        End If
                                        validatedInventory.Insert(firstEmptySlot, item)
                                    Next
                                End If
                            ElseIf wasThief Then
                                If Not IsNothing(lockpickItem) Then
                                    Dim lockpickIndex As Integer = validatedInventory.IndexOf(lockpickItem)
                                    If lockpickIndex <> -1 Then
                                        validatedInventory.RemoveAt(lockpickIndex)
                                        validatedInventory.Add(0)
                                    End If
                                End If

                                Dim equipment As ArrayList = IIf(type = Utilities.GameType.GameTypeFE6, FE6GameData.randomizedFromThiefEquipment,
                                                                 IIf(type = Utilities.GameType.GameTypeFE7, FE7GameData.randomizedFromThiefEquipment,
                                                                     FE8GameData.randomizedFromThiefEquipment))
                                If Not IsNothing(equipment) Then
                                    For Each item As Byte In equipment
                                        Dim firstEmptySlot As Integer = validatedInventory.IndexOf(0)
                                        If firstEmptySlot = -1 Then
                                            Exit For
                                        End If
                                        validatedInventory.Insert(firstEmptySlot, item)
                                    Next
                                End If
                            End If
                        End If

                        If Not newClass.isHealer() Then
                            If Not attackerHasUsableWeapon Then
                                If validWeapons.Count > 0 Then
                                    Dim newWeapon As FEItem = Nothing
                                    Do While (Not Utilities.canCharacterUseWeapon(currentCharacter, newWeapon, newClass))
                                        newWeapon = itemLookup.Item(validWeapons.Item(rng.Next(validWeapons.Count)))
                                        If Not IsNothing(newWeapon) Then
                                            If Not newWeapon.isWeapon() Then
                                                newWeapon = Nothing
                                            End If
                                        End If
                                    Loop
                                    validatedInventory.Insert(0, newWeapon.weaponID)
                                Else
                                End If
                            End If
                        ElseIf Not healerHasHealingStaff Then
                            If type = Utilities.GameType.GameTypeFE6 Then
                                validatedInventory.Insert(0, FE6GameData.ItemList.Heal)
                            ElseIf type = Utilities.GameType.GameTypeFE7 Then
                                validatedInventory.Insert(0, FE7GameData.ItemList.Heal)
                            Else
                                validatedInventory.Insert(0, FE8GameData.ItemList.Heal)
                            End If
                        End If

                        If type = Utilities.GameType.GameTypeFE8 Then
                            ' For FE8, handle monster classes if necesary.
                            Dim monsterClasses As ArrayList = FE8GameData.monsterClassIDs()
                            Dim newClassIDObject As FE8GameData.ClassList = System.Enum.ToObject(GetType(FE8GameData.ClassList), newClassId)
                            If monsterClasses.Contains(newClassIDObject) Then
                                ' Remove any weapons.
                                Dim newInventory As ArrayList = New ArrayList()
                                For Each item In validatedInventory
                                    Dim itemID As Byte = Convert.ToByte(item)
                                    Dim itemObject As FEItem = itemLookup.Item(itemID)
                                    If Not IsNothing(itemObject) Then
                                        If Not itemObject.isWeapon() Then
                                            newInventory.Add(item)
                                        End If
                                    End If
                                Next

                                validatedInventory = newInventory
                                If newClassIDObject = FE8GameData.ClassList.Gorgon Then
                                    validatedInventory.Insert(0, FE8GameData.ItemList.DemonSurge)
                                End If
                                validatedInventory.Insert(0, FE8GameData.randomMonsterWeaponForMonsterClass(newClassId, rng))
                            End If
                        End If

                        While validatedInventory.Count < 4
                            validatedInventory.Add(0)
                        End While

                        While validatedInventory.Count > 4
                            validatedInventory.RemoveAt(validatedInventory.Count - 1)
                        End While

                        unit.item1Id = validatedInventory.Item(0)
                        unit.item2Id = validatedInventory.Item(1)
                        unit.item3Id = validatedInventory.Item(2)
                        unit.item4Id = validatedInventory.Item(3)
                    End If
                Next
            Next

            ' Fix promotion items, though only do this if necessary.
            If Not IsNothing(promotionManager) Then
                If type = Utilities.GameType.GameTypeFE6 Then
                    If randomLords Then
                        promotionManager.addClassToPromotionItem(FE6GameData.ClassList.Lord, promotionManager.PromotionItems.KnightCrest)
                    End If
                    If uniqueClasses Then
                        Dim soldierClass As FEClass = classLookup.Item(Convert.ToByte(FE6GameData.ClassList.Soldier))
                        If Not IsNothing(soldierClass) Then
                            promotionManager.addClassToPromotionItem(FE6GameData.ClassList.Soldier, promotionManager.PromotionItems.KnightCrest)
                            soldierClass.promotedClassId = FE6GameData.ClassList.General
                        End If
                    End If
                ElseIf type = Utilities.GameType.GameTypeFE7 Then
                    If randomLords Then
                        promotionManager.addClassToPromotionItem(FE7GameData.ClassList.LynLord, promotionManager.PromotionItems.HeroCrest)
                        promotionManager.addClassToPromotionItem(FE7GameData.ClassList.EliwoodLord, promotionManager.PromotionItems.KnightCrest)
                        promotionManager.addClassToPromotionItem(FE7GameData.ClassList.HectorLord, promotionManager.PromotionItems.KnightCrest)

                        promotionManager.addClassToPromotionItem(FE7GameData.ClassList.LynLord, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE7GameData.ClassList.EliwoodLord, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE7GameData.ClassList.HectorLord, promotionManager.PromotionItems.MasterSeal)
                    End If
                    If uniqueClasses Then
                        Dim soldierClass As FEClass = classLookup.Item(Convert.ToByte(FE7GameData.ClassList.Soldier))
                        If Not IsNothing(soldierClass) Then
                            soldierClass.promotedClassId = FE7GameData.ClassList.General
                            promotionManager.addClassToPromotionItem(FE7GameData.ClassList.Soldier, promotionManager.PromotionItems.KnightCrest)
                            promotionManager.addClassToPromotionItem(FE7GameData.ClassList.Soldier, promotionManager.PromotionItems.MasterSeal)
                        End If
                    End If
                ElseIf type = Utilities.GameType.GameTypeFE8 Then
                    If randomLords Then
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.EirikaLord, promotionManager.PromotionItems.KnightCrest)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.EphraimLord, promotionManager.PromotionItems.KnightCrest)

                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.EirikaLord, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.EphraimLord, promotionManager.PromotionItems.MasterSeal)
                    End If
                    If uniqueClasses Then
                        Dim soldierClass As FEClass = classLookup.Item(Convert.ToByte(FE8GameData.ClassList.Soldier))
                        If Not IsNothing(soldierClass) Then
                            soldierClass.promotedClassId = FE8GameData.ClassList.General

                            promotionManager.setPromotionBranchesForClass(FE8GameData.ClassList.Soldier, FE8GameData.ClassList.General, FE8GameData.ClassList.Paladin)

                            promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Soldier, promotionManager.PromotionItems.KnightCrest)
                            promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Soldier, promotionManager.PromotionItems.MasterSeal)
                        End If
                        ' Handle ALL the monster classes.
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Zombie, promotionManager.PromotionItems.HeroCrest)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Zombie, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Skeleton, promotionManager.PromotionItems.HeroCrest)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Skeleton, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.SkeletonWithBow, promotionManager.PromotionItems.OrionBolt)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.SkeletonWithBow, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Bael, promotionManager.PromotionItems.KnightCrest)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Bael, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Mauthedoog, promotionManager.PromotionItems.HeroCrest)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Mauthedoog, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Tarvos, promotionManager.PromotionItems.KnightCrest)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Tarvos, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Mogall, promotionManager.PromotionItems.GuidingRing)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Mogall, promotionManager.PromotionItems.MasterSeal)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Gargoyle, promotionManager.PromotionItems.ElysianWhip)
                        promotionManager.addClassToPromotionItem(FE8GameData.ClassList.Gargoyle, promotionManager.PromotionItems.MasterSeal)
                    End If
                End If
            End If

        End If

        If buffEnemies Then
            If buffType = EnemyBuffType.BuffTypeSetConstant Then
                For Each characterClass As FEClass In classList
                    characterClass.buffByAmount(buffAmount)
                Next
            ElseIf buffType = EnemyBuffType.BuffTypeSetMaximum Then
                For Each characterClass As FEClass In classList
                    characterClass.buffUpToAmount(buffAmount, rng)
                Next
            ElseIf buffType = EnemyBuffType.BuffTypeSetMinimum Then
                For Each characterClass As FEClass In classList
                    characterClass.buffAtLeastAmount(buffAmount, rng)
                Next
            End If

            If buffBosses Then
                If type = Utilities.GameType.GameTypeFE6 Then
                    Dim bossList As ArrayList = New ArrayList(FE6GameData.bossCharacterIDs)
                    For Each character As FECharacter In characterList
                        Dim characterIDObject As FE6GameData.CharacterList = System.Enum.ToObject(GetType(FE6GameData.CharacterList), character.characterId)
                        If bossList.Contains(characterIDObject) Then
                            Dim characterClass As FEClass = classLookup.Item(character.classId)
                            character.buffHPWithAdditionalLevelsAtRate(character.level, characterClass.hpGrowthDelta, characterClass.hpCap, rng)
                            character.buffStrWithAdditionalLevelsAtRate(character.level, characterClass.strGrowthDelta, characterClass.strCap, rng)
                            character.buffSklWithAdditionalLevelsAtRate(character.level, characterClass.sklGrowthDelta, characterClass.sklCap, rng)
                            character.buffSpdWithAdditionalLevelsAtRate(character.level, characterClass.spdGrowthDelta, characterClass.spdCap, rng)
                            character.buffLckWithAdditionalLevelsAtRate(character.level, characterClass.lckGrowthDelta, 30, rng)
                            character.buffDefWithAdditionalLevelsAtRate(character.level, characterClass.defGrowthDelta, characterClass.defCap, rng)
                            character.buffResWithAdditionalLevelsAtRate(character.level, characterClass.resGrowthDelta, characterClass.resCap, rng)
                        End If
                    Next
                ElseIf type = Utilities.GameType.GameTypeFE7 Then
                    Dim bossList As ArrayList = New ArrayList(FE7GameData.bossCharacterIDs)
                    For Each character As FECharacter In characterList
                        Dim characterIDObject As FE7GameData.CharacterList = System.Enum.ToObject(GetType(FE7GameData.CharacterList), character.characterId)
                        If bossList.Contains(characterIDObject) Then
                            Dim characterClass As FEClass = classLookup.Item(character.classId)
                            character.buffHPWithAdditionalLevelsAtRate(character.level, characterClass.hpGrowthDelta, characterClass.hpCap, rng)
                            character.buffStrWithAdditionalLevelsAtRate(character.level, characterClass.strGrowthDelta, characterClass.strCap, rng)
                            character.buffSklWithAdditionalLevelsAtRate(character.level, characterClass.sklGrowthDelta, characterClass.sklCap, rng)
                            character.buffSpdWithAdditionalLevelsAtRate(character.level, characterClass.spdGrowthDelta, characterClass.spdCap, rng)
                            character.buffLckWithAdditionalLevelsAtRate(character.level, characterClass.lckGrowthDelta, 30, rng)
                            character.buffDefWithAdditionalLevelsAtRate(character.level, characterClass.defGrowthDelta, characterClass.defCap, rng)
                            character.buffResWithAdditionalLevelsAtRate(character.level, characterClass.resGrowthDelta, characterClass.resCap, rng)
                        End If
                    Next
                ElseIf type = Utilities.GameType.GameTypeFE8 Then
                    Dim bossList As ArrayList = New ArrayList(FE8GameData.bossCharacterIDs)
                    For Each character As FECharacter In characterList
                        Dim characterIDObject As FE8GameData.CharacterList = System.Enum.ToObject(GetType(FE8GameData.CharacterList), character.characterId)
                        If bossList.Contains(characterIDObject) Then
                            Dim characterClass As FEClass = classLookup.Item(character.classId)
                            character.buffHPWithAdditionalLevelsAtRate(character.level, characterClass.hpGrowthDelta, characterClass.hpCap, rng)
                            character.buffStrWithAdditionalLevelsAtRate(character.level, characterClass.strGrowthDelta, characterClass.strCap, rng)
                            character.buffSklWithAdditionalLevelsAtRate(character.level, characterClass.sklGrowthDelta, characterClass.sklCap, rng)
                            character.buffSpdWithAdditionalLevelsAtRate(character.level, characterClass.spdGrowthDelta, characterClass.spdCap, rng)
                            character.buffLckWithAdditionalLevelsAtRate(character.level, characterClass.lckGrowthDelta, 30, rng)
                            character.buffDefWithAdditionalLevelsAtRate(character.level, characterClass.defGrowthDelta, characterClass.defCap, rng)
                            character.buffResWithAdditionalLevelsAtRate(character.level, characterClass.resGrowthDelta, characterClass.resCap, rng)
                        End If
                    Next
                End If
            End If
        End If

        ' Write it all back to disk.

        ' Apply any patches if necessary.
        If type = Utilities.GameType.GameTypeFE7 And applyTutorialKiller Then
            Dim result As Boolean = Patcher.applyUPSPatch(OpenFileDialog1.FileName, "Arch's Tutorial Slayer.ups")
            If result = False Then
                MsgBox("Tutorial Killer Patch Failed. Continuing without applying patch...", MsgBoxStyle.OkOnly, "Notice")
            Else
                applyTutorialKiller = False
                GameSpecificCheckbox.Checked = False
            End If
        End If

        Dim fileWriter = IO.File.OpenWrite(OpenFileDialog1.FileName)

        fileWriter.Seek(characterTableOffset, IO.SeekOrigin.Begin)

        ' At least for FE6, the first item always seems to be some junk that we don't want to overwrite.
        ' The ROM uses these addresses in its code though, so I guess it always starts with 1 index.
        For index As Integer = 0 To characterList.Count - 1
            If index = 0 Then
                fileWriter.Seek(characterEntrySize, IO.SeekOrigin.Current)
            Else
                Dim character As FECharacter = characterList.Item(index)
                ' One last validation before writing.
                character.validate(classLookup.Item(character.classId), minimumCON, type)
                character.writeStatsToCharacterStartingAtOffset(fileWriter, fileWriter.Position, characterEntrySize, type)
            End If
        Next

        fileWriter.Seek(classTableOffset, IO.SeekOrigin.Begin)

        For index As Integer = 0 To classList.Count - 1
            If index = 0 Then
                fileWriter.Seek(classEntrySize, IO.SeekOrigin.Current)
            Else
                Dim currentClass As FEClass = classList.Item(index)
                currentClass.writeClassStartingAtOffset(fileWriter, fileWriter.Position, classEntrySize, type)
            End If
        Next

        fileWriter.Seek(itemTableOffset, IO.SeekOrigin.Begin)

        For index As Integer = 0 To itemList.Count - 1
            If index = 0 Then
                fileWriter.Seek(itemEntrySize, IO.SeekOrigin.Current)
            Else
                Dim currentItem As FEItem = itemList.Item(index)
                currentItem.writeItemToOffset(fileWriter, fileWriter.Position, itemEntrySize, type)
            End If
        Next

        If type = Utilities.GameType.GameTypeFE6 Then
            Dim chapterPointers As Array = System.Enum.GetValues(GetType(FE6GameData.ChapterUnitReference))
            Dim chapterUnitCounts As ArrayList = FE6GameData.UnitsInEachChapter()

            For i As Integer = 0 To chapterPointers.Length - 1
                Dim pointer = chapterPointers(i)
                Dim unitCount = chapterUnitCounts.Item(i)
                fileWriter.Seek(pointer, IO.SeekOrigin.Begin)
                Dim unitList As ArrayList = chapterUnitData.Item(i)
                For j As Integer = 0 To unitList.Count - 1
                    Dim unit As FEChapterUnit = unitList.Item(j)
                    unit.writeChapterUnitToOffset(fileWriter, fileWriter.Position, FE6GameData.ChapterUnitEntrySize, Utilities.GameType.GameTypeFE6)
                Next
            Next
        ElseIf type = Utilities.GameType.GameTypeFE7 Then
            Dim chapterPointers As Array = System.Enum.GetValues(GetType(FE7GameData.ChapterUnitReference))
            Dim chapterUnitCounts As ArrayList = FE7GameData.UnitsInEachChapter()

            For i As Integer = 0 To chapterPointers.Length - 1
                Dim pointer = chapterPointers(i)
                Dim unitCount = chapterUnitCounts.Item(i)
                fileWriter.Seek(pointer, IO.SeekOrigin.Begin)
                Dim unitList As ArrayList = chapterUnitData.Item(i)
                For j As Integer = 0 To unitList.Count - 1
                    Dim unit As FEChapterUnit = unitList.Item(j)
                    unit.writeChapterUnitToOffset(fileWriter, fileWriter.Position, FE7GameData.ChapterUnitEntrySize, Utilities.GameType.GameTypeFE7)
                Next
            Next
        ElseIf type = Utilities.GameType.GameTypeFE8 Then
            Dim chapterPointers As Array = System.Enum.GetValues(GetType(FE8GameData.ChapterUnitReference))
            Dim chapterUnitCounts As ArrayList = FE8GameData.UnitsInEachChapter()

            For i As Integer = 0 To chapterPointers.Length - 1
                Dim pointer = chapterPointers(i)
                Dim unitCount = chapterUnitCounts.Item(i)
                fileWriter.Seek(pointer, IO.SeekOrigin.Begin)
                Dim unitList As ArrayList = chapterUnitData.Item(i)
                For j As Integer = 0 To unitList.Count - 1
                    Dim unit As FEChapterUnit = unitList.Item(j)
                    unit.writeChapterUnitToOffset(fileWriter, fileWriter.Position, FE8GameData.ChapterUnitEntrySize, Utilities.GameType.GameTypeFE8)
                Next
            Next
        End If

        If Not IsNothing(quoteManager) Then
            quoteManager.commitChanges(fileWriter)
        End If
        If Not IsNothing(supportManager) Then
            supportManager.commitChanges(fileWriter)
        End If
        If Not IsNothing(spellAssociationManager) Then
            spellAssociationManager.commitChanges(fileWriter)
        End If
        If Not IsNothing(promotionManager) Then
            promotionManager.commitChanges(fileWriter)
        End If

        If Not hasAlreadyRandomized Then
            ' Leave a signature so that we don't re-randomize the same files.
            fileWriter.Seek(0, IO.SeekOrigin.End)
            fileWriter.Write(System.Text.Encoding.ASCII.GetBytes("GFR1"), 0, 4)

            hasAlreadyRandomized = True
        End If

        fileWriter.Close()

        MsgBox("Randomized!", MsgBoxStyle.OkOnly, "Notice")

        reenableAllControls()

    End Sub

    Private Sub disableAllControls()
        BrowseButton.Enabled = False

        RandomizeGrowthsToggle.Enabled = False
        GrowthVarianceControl.Enabled = False
        MinimumGrowthToggle.Enabled = False
        WeightedHPGrowthsToggle.Enabled = False

        RandomizeBasesToggle.Enabled = False
        BaseVarianceControl.Enabled = False
        RandomizeCONToggle.Enabled = False
        CONVarianceControl.Enabled = False
        MinimumCONControl.Enabled = False
        RandomizeMOVToggle.Enabled = False
        MinimumMOVControl.Enabled = False
        MaximumMOVControl.Enabled = False

        RandomizeAffinityToggle.Enabled = False

        RandomizeClassesToggle.Enabled = False
        IncludeLordsToggle.Enabled = False
        IncludeThievesToggle.Enabled = False
        IncludeBossesToggle.Enabled = False
        AllowUniqueClassesToggle.Enabled = False

        RandomizeItemsToggle.Enabled = False
        MightVarianceControl.Enabled = False
        MinimumMightControl.Enabled = False
        HitVarianceControl.Enabled = False
        MinimumHitControl.Enabled = False
        CriticalVarianceControl.Enabled = False
        MinimumCriticalControl.Enabled = False
        WeightVarianceControl.Enabled = False
        MinimumWeightControl.Enabled = False
        MaximumWeightControl.Enabled = False
        MinimumDurabilityControl.Enabled = False
        DurabilityVarianceControl.Enabled = False
        AllowRandomTraitsToggle.Enabled = False

        IncreaseEnemyGrowthsToggle.Enabled = False
        EnemyBuffControl.Enabled = False
        SetMinimumEnemyBuffControl.Enabled = False
        SetMaximumEnemyBuffControl.Enabled = False
        SetConstantEnemyBuffControl.Enabled = False
        BuffBossesToggle.Enabled = False

        NormalRecruitmentOption.Enabled = False
        ReverseRecruitmentOption.Enabled = False
        RandomRecruitmentOption.Enabled = False

        RandomizeButton.Enabled = False
    End Sub

    Private Sub reenableAllControls()
        BrowseButton.Enabled = True

        RandomizeGrowthsToggle.Enabled = True
        GrowthVarianceControl.Enabled = RandomizeGrowthsToggle.Checked
        MinimumGrowthToggle.Enabled = RandomizeGrowthsToggle.Checked
        WeightedHPGrowthsToggle.Enabled = RandomizeGrowthsToggle.Checked

        RandomizeBasesToggle.Enabled = True
        BaseVarianceControl.Enabled = RandomizeBasesToggle.Checked

        RandomizeCONToggle.Enabled = True
        CONVarianceControl.Enabled = RandomizeCONToggle.Checked
        MinimumCONControl.Enabled = RandomizeCONToggle.Checked

        RandomizeMOVToggle.Enabled = True
        MinimumMOVControl.Enabled = RandomizeMOVToggle.Checked
        MaximumMOVControl.Enabled = RandomizeMOVToggle.Checked

        RandomizeAffinityToggle.Enabled = True

        RandomizeClassesToggle.Enabled = True
        IncludeLordsToggle.Enabled = RandomizeClassesToggle.Checked
        IncludeThievesToggle.Enabled = RandomizeClassesToggle.Checked
        IncludeBossesToggle.Enabled = RandomizeClassesToggle.Checked
        AllowUniqueClassesToggle.Enabled = RandomizeClassesToggle.Checked

        RandomizeItemsToggle.Enabled = True
        MightVarianceControl.Enabled = RandomizeItemsToggle.Checked
        MinimumMightControl.Enabled = RandomizeItemsToggle.Checked
        HitVarianceControl.Enabled = RandomizeItemsToggle.Checked
        MinimumHitControl.Enabled = RandomizeItemsToggle.Checked
        CriticalVarianceControl.Enabled = RandomizeItemsToggle.Checked
        MinimumCriticalControl.Enabled = RandomizeItemsToggle.Checked
        WeightVarianceControl.Enabled = RandomizeItemsToggle.Checked
        MinimumWeightControl.Enabled = RandomizeItemsToggle.Checked
        MaximumWeightControl.Enabled = RandomizeItemsToggle.Checked
        MinimumDurabilityControl.Enabled = RandomizeItemsToggle.Checked
        DurabilityVarianceControl.Enabled = RandomizeItemsToggle.Checked
        AllowRandomTraitsToggle.Enabled = RandomizeItemsToggle.Checked

        IncreaseEnemyGrowthsToggle.Enabled = True
        EnemyBuffControl.Enabled = IncreaseEnemyGrowthsToggle.Checked
        SetMinimumEnemyBuffControl.Enabled = IncreaseEnemyGrowthsToggle.Checked
        SetMaximumEnemyBuffControl.Enabled = IncreaseEnemyGrowthsToggle.Checked
        SetConstantEnemyBuffControl.Enabled = IncreaseEnemyGrowthsToggle.Checked
        BuffBossesToggle.Enabled = IncreaseEnemyGrowthsToggle.Checked

        NormalRecruitmentOption.Enabled = True
        ReverseRecruitmentOption.Enabled = True
        RandomRecruitmentOption.Enabled = True

        RandomizeButton.Enabled = type <> Utilities.GameType.GameTypeUnknown
    End Sub

    Private Sub RandomizeGrowthsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeGrowthsToggle.CheckedChanged
        shouldRandomizeGrowths = RandomizeGrowthsToggle.Checked

        GrowthVarianceControl.Enabled = shouldRandomizeGrowths
        MinimumGrowthToggle.Enabled = shouldRandomizeGrowths
        WeightedHPGrowthsToggle.Enabled = shouldRandomizeGrowths
    End Sub

    Private Sub GrowthVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrowthVarianceControl.ValueChanged
        Dim currentValue = GrowthVarianceControl.Value
        If currentValue Mod 5 <> 0 Then
            currentValue = currentValue + (5 - (currentValue Mod 5))
        End If
        GrowthVarianceControl.Value = currentValue
        growthsVariance = currentValue
    End Sub

    Private Sub MinimumGrowthToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumGrowthToggle.CheckedChanged
        shouldForceMinimumGrowth = MinimumGrowthToggle.Checked
    End Sub

    Private Sub WeightedHPGrowthsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeightedHPGrowthsToggle.CheckedChanged
        shouldWeightHPGrowths = WeightedHPGrowthsToggle.Checked
    End Sub

    Private Sub RandomizeBasesToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeBasesToggle.CheckedChanged
        shouldRandomizeBases = RandomizeBasesToggle.Checked

        BaseVarianceControl.Enabled = shouldRandomizeBases
    End Sub

    Private Sub BaseVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseVarianceControl.ValueChanged
        baseVariance = BaseVarianceControl.Value
    End Sub

    Private Sub RandomizeCONToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeCONToggle.CheckedChanged
        shouldRandomizeCON = RandomizeCONToggle.Checked
        MinimumCONControl.Enabled = shouldRandomizeCON
        CONVarianceControl.Enabled = shouldRandomizeCON
    End Sub

    Private Sub CONVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONVarianceControl.ValueChanged
        CONVariance = CONVarianceControl.Value
    End Sub

    Private Sub MinimumCONControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumCONControl.ValueChanged
        minimumCON = MinimumCONControl.Value
    End Sub

    Private Sub RandomizeMOVToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeMOVToggle.CheckedChanged
        shouldRandomizeMOV = RandomizeMOVToggle.Checked
        MinimumMOVControl.Enabled = shouldRandomizeMOV
        MaximumMOVControl.Enabled = shouldRandomizeMOV
    End Sub

    Private Sub MinimumMOVControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumMOVControl.ValueChanged
        Dim targetMOV = MinimumMOVControl.Value
        If targetMOV > maximumMOV Then
            targetMOV = maximumMOV
        End If
        minimumMOV = targetMOV
        MinimumMOVControl.Value = targetMOV
        MaximumMOVControl.Minimum = targetMOV
    End Sub

    Private Sub MaximumMOVControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximumMOVControl.ValueChanged
        Dim targetMOV = MaximumMOVControl.Value
        If targetMOV < minimumMOV Then
            targetMOV = minimumMOV
        End If
        maximumMOV = targetMOV
        MaximumMOVControl.Value = targetMOV
        MinimumMOVControl.Maximum = targetMOV
    End Sub

    Private Sub RandomizeAffinityToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeAffinityToggle.CheckedChanged
        shouldRandomizeAffinity = RandomizeAffinityToggle.Checked
    End Sub

    Private Sub RandomizeItemsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeItemsToggle.CheckedChanged
        shouldRandomizeItems = RandomizeItemsToggle.Checked

        MightVarianceControl.Enabled = shouldRandomizeItems
        MinimumMightControl.Enabled = shouldRandomizeItems
        HitVarianceControl.Enabled = shouldRandomizeItems
        MinimumHitControl.Enabled = shouldRandomizeItems
        CriticalVarianceControl.Enabled = shouldRandomizeItems
        MinimumCriticalControl.Enabled = shouldRandomizeItems
        WeightVarianceControl.Enabled = shouldRandomizeItems
        MinimumWeightControl.Enabled = shouldRandomizeItems
        MaximumWeightControl.Enabled = shouldRandomizeItems
        MinimumDurabilityControl.Enabled = shouldRandomizeItems
        DurabilityVarianceControl.Enabled = shouldRandomizeItems
        AllowRandomTraitsToggle.Enabled = shouldRandomizeItems
    End Sub

    Private Sub MightVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MightVarianceControl.ValueChanged
        mightVariance = MightVarianceControl.Value
    End Sub

    Private Sub MinimumMightControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumMightControl.ValueChanged
        minimumMight = MinimumMightControl.Value
    End Sub

    Private Sub HitVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HitVarianceControl.ValueChanged
        Dim targetHit = HitVarianceControl.Value
        If targetHit Mod 5 <> 0 Then
            targetHit = targetHit + (5 - targetHit Mod 5)
        End If
        HitVarianceControl.Value = targetHit
        hitVariance = targetHit
    End Sub

    Private Sub MinimumHitControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumHitControl.ValueChanged
        Dim targetHit = MinimumHitControl.Value
        If targetHit Mod 5 <> 0 Then
            targetHit = targetHit + (5 - targetHit Mod 5)
        End If
        minimumHit = targetHit
        MinimumHitControl.Value = targetHit
    End Sub

    Private Sub CriticalVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CriticalVarianceControl.ValueChanged
        Dim targetCrit = CriticalVarianceControl.Value
        If targetCrit Mod 5 <> 0 Then
            targetCrit = targetCrit + (5 - targetCrit Mod 5)
        End If
        criticalVariance = targetCrit
        CriticalVarianceControl.Value = targetCrit
    End Sub

    Private Sub MinimumCriticalControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumCriticalControl.ValueChanged
        Dim targetCrit = MinimumCriticalControl.Value
        If targetCrit Mod 5 <> 0 Then
            targetCrit = targetCrit + (5 - targetCrit Mod 5)
        End If
        minimumCritical = targetCrit
        MinimumCriticalControl.Value = targetCrit
    End Sub

    Private Sub WeightVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeightVarianceControl.ValueChanged
        weightVariance = WeightVarianceControl.Value
    End Sub

    Private Sub MinimumWeightControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumWeightControl.ValueChanged
        Dim targetWeight = MinimumWeightControl.Value
        If targetWeight > maximumWeight Then
            targetWeight = maximumWeight
        End If

        minimumWeight = targetWeight
        MinimumWeightControl.Value = targetWeight
        MaximumWeightControl.Minimum = targetWeight
    End Sub

    Private Sub MaximumWeightControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximumWeightControl.ValueChanged
        Dim targetWeight = MaximumWeightControl.Value
        If targetWeight < minimumWeight Then
            targetWeight = minimumWeight
        End If

        maximumWeight = targetWeight
        MaximumWeightControl.Value = targetWeight
        MinimumWeightControl.Maximum = targetWeight
    End Sub

    Private Sub DurabilityVarianceControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DurabilityVarianceControl.ValueChanged
        durabilityVariance = DurabilityVarianceControl.Value
    End Sub

    Private Sub MinimumDurabilityControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumDurabilityControl.ValueChanged
        minimumDurability = MinimumDurabilityControl.Value
    End Sub

    Private Sub AllowRandomTraitsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllowRandomTraitsToggle.CheckedChanged
        randomTraits = AllowRandomTraitsToggle.Checked
    End Sub

    Private Sub RandomizeClassesToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomizeClassesToggle.CheckedChanged
        shouldRandomizeClasses = RandomizeClassesToggle.Checked

        IncludeLordsToggle.Enabled = shouldRandomizeClasses
        IncludeThievesToggle.Enabled = shouldRandomizeClasses
        IncludeBossesToggle.Enabled = shouldRandomizeClasses
        AllowUniqueClassesToggle.Enabled = shouldRandomizeClasses
    End Sub

    Private Sub IncludeLordsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeLordsToggle.CheckedChanged
        randomLords = IncludeLordsToggle.Checked
    End Sub

    Private Sub IncludeThievesToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeThievesToggle.CheckedChanged
        randomThieves = IncludeThievesToggle.Checked
    End Sub

    Private Sub IncludeBossesToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeBossesToggle.CheckedChanged
        randomBosses = IncludeBossesToggle.Checked
    End Sub

    Private Sub AllowUniqueClassesToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllowUniqueClassesToggle.CheckedChanged
        uniqueClasses = AllowUniqueClassesToggle.Checked
    End Sub

    Private Sub IncreaseEnemyGrowthsToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncreaseEnemyGrowthsToggle.CheckedChanged
        buffEnemies = IncreaseEnemyGrowthsToggle.Checked

        EnemyBuffControl.Enabled = buffEnemies
        SetMaximumEnemyBuffControl.Enabled = buffEnemies
        SetConstantEnemyBuffControl.Enabled = buffEnemies
        SetMinimumEnemyBuffControl.Enabled = buffEnemies
        BuffBossesToggle.Enabled = buffEnemies
    End Sub

    Private Sub EnemyBuffControl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnemyBuffControl.ValueChanged
        Dim targetAmount = EnemyBuffControl.Value
        If targetAmount Mod 5 <> 0 Then
            targetAmount = targetAmount + (5 - targetAmount Mod 5)
        End If
        buffAmount = targetAmount
        EnemyBuffControl.Value = targetAmount
    End Sub

    Private Sub SetMaximumEnemyBuffControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetMaximumEnemyBuffControl.CheckedChanged
        If SetMaximumEnemyBuffControl.Checked Then
            buffType = EnemyBuffType.BuffTypeSetMaximum
            SetConstantEnemyBuffControl.Checked = False
            SetMinimumEnemyBuffControl.Checked = False
        End If
    End Sub

    Private Sub SetConstantEnemyBuffControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetConstantEnemyBuffControl.CheckedChanged
        If SetConstantEnemyBuffControl.Checked Then
            buffType = EnemyBuffType.BuffTypeSetConstant
            SetMinimumEnemyBuffControl.Checked = False
            SetMaximumEnemyBuffControl.Checked = False
        End If
    End Sub

    Private Sub SetMinimumEnemyBuffControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetMinimumEnemyBuffControl.CheckedChanged
        If SetMinimumEnemyBuffControl.Checked Then
            buffType = EnemyBuffType.BuffTypeSetMinimum
            SetMaximumEnemyBuffControl.Checked = False
            SetConstantEnemyBuffControl.Checked = False
        End If
    End Sub

    Private Sub BuffBossesToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuffBossesToggle.CheckedChanged
        buffBosses = BuffBossesToggle.Checked
    End Sub

    Private Sub NormalRecruitmentOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalRecruitmentOption.CheckedChanged
        If NormalRecruitmentOption.Checked Then
            recruitment = RecruitmentType.RecruitmentTypeNormal
            ReverseRecruitmentOption.Checked = False
            RandomRecruitmentOption.Checked = False
        End If
    End Sub

    Private Sub ReverseRecruitmentOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReverseRecruitmentOption.CheckedChanged
        If ReverseRecruitmentOption.Checked Then
            recruitment = RecruitmentType.RecruitmentTypeReverse
            NormalRecruitmentOption.Checked = False
            RandomRecruitmentOption.Checked = False
        End If
    End Sub

    Private Sub RandomRecruitmentOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomRecruitmentOption.CheckedChanged
        If RandomRecruitmentOption.Checked Then
            recruitment = RecruitmentType.RecruitmentTypeRandom
            NormalRecruitmentOption.Checked = False
            ReverseRecruitmentOption.Checked = False
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disableAllControls()
        BrowseButton.Enabled = True

        applyTutorialKiller = False

        ' The default min CON is 1
        minimumCON = 1
        ' The default min MOV is 1 and the default max MOV is 9
        minimumMOV = 1
        maximumMOV = 9
        ' The default weapon max weapon weight is 20 and the default min weapon weight is 1
        minimumWeight = 1
        maximumWeight = 20
        ' The default minimum durability is 1
        minimumDurability = 1

        GrowthsTooltip.SetToolTip(RandomizeGrowthsToggle, "Applies a random growth to all characters (playable and bosses). " + vbCrLf _
                    & "A character's original growths are added together and then" + vbCrLf _
                    & "redistributed across all growth areas to generate their new growths." + vbCrLf _
                    & "Redistribution is done by randomizing a stat, then randomizing an amount." + vbCrLf _
                    & "The amount is added to the running total for the stat growth. This" + vbCrLf _
                    & "repeats until their total growth is reached." + vbCrLf _
                    & "Growths may range from 0% to 255%.")
        GrowthsVarianceTooltip.SetToolTip(GrowthVarianceControl, "Before redistributing growths, a random amount from 0" + vbCrLf _
                                    & "and the amount entered (in increments of 5%) is either" + vbCrLf _
                                    & "added to or subtracted from a character's total growths." + vbCrLf _
                                    & "Maximum varaince is 100.")
        MinimumGrowthTooltip.SetToolTip(MinimumGrowthToggle, "Before redistributing growths, 5% is assigned to each" + vbCrLf _
                                        & "growth area and subtracted from the total. This ensures" + vbCrLf _
                                        & "the lowest growth a stat can have is 5%.")
        WeightedHPTooltip.SetToolTip(WeightedHPGrowthsToggle, "While redistributing growths, if the randomized stat is HP," + vbCrLf _
                                     & "then it will gain an additional 10% on top of the randomized amount." + vbCrLf _
                                     & "This makes it more likely HP will be the higher growth.")

        BasesTooltip.SetToolTip(RandomizeBasesToggle, "Applies random bases to all characters (playable and bosses)." + vbCrLf _
                                & "A character's original bases are added together and then" + vbCrLf _
                                & "redistributed across all stats to generate their new bases." + vbCrLf _
                                & "Redistribution is done by first randomizing a stat." + vbCrLf _
                                & "If the stat is HP, a random number between 1 and 5 is added to their HP base." + vbCrLf _
                                & "On STR/MAG/SPD/DEF, a random number between 1 and 2 is added to the stat base." + vbCrLf _
                                & "On SKL/RES, a random number between 1 and 3 is added to the stat base." + vbCrLf _
                                & "On LCK, a random number beween 1 and 4 is added to the stat base.")
        BaseVarianceTooltip.SetToolTip(BaseVarianceControl, "Before redistributing bases, a random amount from 0" + vbCrLf _
                                       & "and the amount entered is either added or subtracted from the" + vbCrLf _
                                       & "character's total growth. Maximum variance is 10.")

        CONTooltip.SetToolTip(RandomizeCONToggle, "Generates a random number with a magnitude specified by the Variance" + vbCrLf _
                              & "and applies it to a character's original CON adjustment. This applies to" + vbCrLf _
                              & "both playable characters and bosses.")
        CONVarianceTooltip.SetToolTip(CONVarianceControl, "Determines the maximum magnitude of any CON change. Values will" + vbCrLf _
                                      & "range from the -x and +x where x is the number shown here.")
        MinimumCONTooltip.SetToolTip(MinimumCONControl, "Enforces a minimum value for the CON stat for all characters." + vbCrLf _
                                     & "The CON value specified should be the final CON after applying adjustments." + vbCrLf _
                                     & "Any unit with a CON less than this value will have it brought up to this value.")

        MOVTooltip.SetToolTip(RandomizeMOVToggle, "Generates a random number between the specified minimum MOV" + vbCrLf _
                              & "and specified maximum MOV for all classes. Note that this applies on a class" + vbCrLf _
                              & "as opposed to a single character. The minimum MOV is 1 and the maximum MOV is 9.")
        MinimumMOVTooltip.SetToolTip(MinimumMOVControl, "Sets the minimum MOV allowed for any class." + vbCrLf _
                                     & "This value must be between 1 and the maximum MOV.")
        MaximumMOVTooltip.SetToolTip(MaximumMOVControl, "Sets the maximum MOV allowed for any class." + vbCrLf _
                                     & "This value must be between the minimum MOV and 9.")

        RandomAffinityTooltip.SetToolTip(RandomizeAffinityToggle, "Sets a random affinity for every character (playable" + vbCrLf _
                                         & "and bosses). Most enemies don't get support bonuses, so it really only" + vbCrLf _
                                         & "affects playable characters.")

        RandomItemsTooltip.SetToolTip(RandomizeItemsToggle, "Iterates through all weapons and applies a random adjustment to their" + vbCrLf _
                                      & "relevant stats. Only weapons are affected by this. Items are ignored.")
        MightVarianceTooltip.SetToolTip(MightVarianceControl, "Sets the maximum allowed variance on the MT stat of all weapons." + vbCrLf _
                                        & "A random number up to the number here is either added to or subtracted from a weapon's base MT." + vbCrLf _
                                        & "The maximum allowed variance is 10 (i.e. +/- 10).")
        MinimumMightTooltip.SetToolTip(MinimumMightControl, "Sets the minimum allowed MT on any weapon. Weapons with less MT" + vbCrLf _
                                       & "than the amount specified here will have their MT increased to this amount." + vbCrLf _
                                       & "This value must be between 0 and 10.")
        HitVarianceTooltip.SetToolTip(HitVarianceControl, "Sets the maximum allowed variance on the HIT stat of all weapons." + vbCrLf _
                                      & "A random number up to the number here (in increments of 5) is either added to or subtracted from" + vbCrLf _
                                      & "a weapon's base HIT. The maximum allowed variance is 100 (i.e. +/- 100).")
        MinimumHitTooltip.SetToolTip(MinimumHitControl, "Sets the minimum allowed HIT on any weapon. Weapons with less HIT" + vbCrLf _
                                     & "than the amount specified here will have their HIT increased to this amount." + vbCrLf _
                                     & "This value must be between 0 and 100.")
        CriticalVarianceTooltip.SetToolTip(CriticalVarianceControl, "Sets the maximum allowed variance on the CRIT stat of all weapons." + vbCrLf _
                                           & "A random number up to the number here (in increments of 5) is either added to or subtracted from" + vbCrLf _
                                           & "a weapon's base CRIT. The maximum allowed variance is 50 (i.e. +/- 50).")
        MinimumCriticalTooltip.SetToolTip(MinimumCriticalControl, "Sets the minimum allowed CRIT on any weapon. Weapons with less CRIT" + vbCrLf _
                                          & "than the amount specified here will have their CRIT increased to this amount." + vbCrLf _
                                          & "This value must be between 0 and 30.")
        WeightVarianceTooltip.SetToolTip(WeightVarianceControl, "Sets the maximum allowed variance on the WT stat of all weapons." + vbCrLf _
                                         & "A random number up to the number here is added to or subtracted from" + vbCrLf _
                                         & "a weapon's base WT. The maximum allowed variance is 10 (i.e. +/- 10).")
        MinimumWeightTooltip.SetToolTip(MinimumWeightControl, "Sets the minimum allowed WT on any weapon. Weapons with less WT" + vbCrLf _
                                        & "than the amount specified here will have their WT increased to this amount." + vbCrLf _
                                        & "This value must be between 1 and the maximum weight specified.")
        MaximumWeightTooltip.SetToolTip(MaximumWeightControl, "Sets the maximum allowed WT on any weapon. Weapons with more WT" + vbCrLf _
                                        & "than the amount specified here will have their WT reduced to this amount." + vbCrLf _
                                        & "This value must be between the minimum weight specified and 50.")
        DurabilityVarianceTooltip.SetToolTip(DurabilityVarianceControl, "Sets the maximum allowed variance on the durability of all weapons." + vbCrLf _
                                             & "A random number up to the number here is either added to or subtracted from" + vbCrLf _
                                             & "a weapon's durability. The maximum allowed variance is 49.")
        MinimumDurabilityTooltip.SetToolTip(MinimumDurabilityControl, "Sets the minimum allowed durability on any weapon. Weapons with" + vbCrLf _
                                            & "less durability than the amount specified here will have their durability increased" + vbCrLf _
                                            & "to this amount. This value must be between 1 and 50.")
        AllowRandomTraitsTooltip.SetToolTip(AllowRandomTraitsToggle, "While randomizing weapons, allow the random assignment of weapon traits" + vbCrLf _
                                            & "to weapons. This includes 1 of the following: Reverses Weapon Triangle, Unbreakable, Brave," + vbCrLf _
                                            & "Magic Damage (physical weapons only), Uncounterable, A random effectiveness, A Random Stat Bonus, Poison On Hit," + vbCrLf _
                                            & "Halves HP, or Devil Reversal. For FE7 and FE8, Negates Defenses is also a possibility." + vbCrLf _
                                            & "Weapons already with an effect retain their original effect in addition to a new random trait.")

        RandomClassesTooltip.SetToolTip(RandomizeClassesToggle, "Assigns a random class to characters in the chapter data." + vbCrLf _
                                        & "By default, this randomizes all non-lord, non-thief playable characters." + vbCrLf _
                                        & "All units will have their inventories reset to allow them to be effective upon joining." + vbCrLf _
                                        & "Weapon ranks will also be reset to correspond to their respective classes." + vbCrLf _
                                        & "Only classes that can promote (or already promoted classes) will show up by default.")
        RandomizeLordsTooltip.SetToolTip(IncludeLordsToggle, "Also randomize lord characters to different classes. Also adds lords to" + vbCrLf _
                                         & "the pool of classes available for other units.")
        RandomizeThievesTooltip.SetToolTip(IncludeThievesToggle, "Also randomize thief characters to different classes. Also adds thieves to" + vbCrLf _
                                           & "the pool of classes available for other units.")
        RandomizeBossesTooltip.SetToolTip(IncludeBossesToggle, "Also randomize boss characters to different classes. This does not modify classes" + vbCrLf _
                                          & "of boss characters with unique classes (most final bosses).")
        UniqueClassesTooltip.SetToolTip(AllowUniqueClassesToggle, "Allow unique classes from each game into the random pool of classes available." + vbCrLf _
                                        & "Additionally, this allows classes that do not promote (such as Soldier) into the pool as well and they" + vbCrLf _
                                        & "will continue to be unpromotable. For FE8, this adds monster classes to the pool.")

        EnemyBuffTooltip.SetToolTip(IncreaseEnemyGrowthsToggle, "Increases the growths of all classes by a constant or random amount." + vbCrLf _
                                    & "Playable characters override this growth so this does not affect them.")
        BuffAmountTooltip.SetToolTip(EnemyBuffControl, "Sets the amount to buff all class growths by. The buff amount is in percentages" + vbCrLf _
                                     & "and the result is added to the every class's growth rates. The options below" + vbCrLf _
                                     & "dictate how to use this value." + vbCrLf _
                                     & """Up To Amount"" generates a random value beween 0 and the value specified to be added to growths." + vbCrLf _
                                     & """Exactly Amount"" adds the listed value to all stat areas for all classes." + vbCrLf _
                                     & """At Least Amount"" adds a random value between the listed amount and 255 to the growths (capping at 255 growth).")
        BossBuffTooltip.SetToolTip(BuffBossesToggle, "By default, bosses also override growths and will not autolevel to match their" + vbCrLf _
                                   & "subordinates. Enabling this adjusts this by applying a small (random) amount to bases to correct for that.")

        RecruitmentTooltip.SetToolTip(RecruitmentBox, "Modifies the recruitment order for the game." + vbCrLf _
                                      & """Normal"" is the default order." + vbCrLf _
                                      & """Reversed"" mirrors the recruitment order, making the last few characters join first and vice versa." + vbCrLf _
                                      & """Randomized"" takes all of the characters and drops them into random recruitment slots." + vbCrLf _
                                      & "Note that dialogue referring to characters does not change.")
    End Sub

End Class