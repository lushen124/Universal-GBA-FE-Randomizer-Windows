Imports WindowsApplication1

Public Class RandomizeSettings

    Public Enum RecruitmentType
        RecruitmentTypeNormal
        RecruitmentTypeReverse
        RecruitmentTypeRandom
    End Enum

    Public Enum EnemyBuffType
        BuffTypeSetConstant
        BuffTypeSetMaximum
    End Enum

    Public Shared Property shouldRandomizeGrowths As Boolean
    Public Shared Property growthsVariance As Integer
    Public Shared Property shouldForceMinimumGrowth As Boolean
    Public Shared Property shouldWeightHPGrowths As Boolean

    Public Shared Property shouldRandomizeBases As Boolean
    Public Shared Property baseVariance As Integer
    Public Shared Property shouldRandomizeCON As Boolean
    Public Shared Property CONVariance As Integer
    Public Shared Property minimumCON As Integer
    Public Shared Property shouldRandomizeMOV As Boolean
    Public Shared Property minimumMOV As Integer
    Public Shared Property maximumMOV As Integer

    Public Shared Property shouldRandomizeAffinity As Boolean

    Public Shared Property shouldRandomizeClasses As Boolean
    Public Shared Property randomLords As Boolean
    Public Shared Property randomThieves As Boolean
    Public Shared Property randomBosses As Boolean
    Public Shared Property uniqueClasses As Boolean
    Public Shared Property crossgender As Boolean

    Public Shared Property shouldRandomizeItems As Boolean
    Public Shared Property mightVariance As Integer
    Public Shared Property minimumMight As Integer
    Public Shared Property hitVariance As Integer
    Public Shared Property minimumHit As Integer
    Public Shared Property criticalVariance As Integer
    Public Shared Property minimumCritical As Integer
    Public Shared Property weightVariance As Integer
    Public Shared Property minimumWeight As Integer
    Public Shared Property maximumWeight As Integer
    Public Shared Property durabilityVariance As Integer
    Public Shared Property minimumDurability As Integer
    Public Shared Property randomTraits As Boolean

    Public Shared Property buffEnemies As Boolean
    Public Shared Property buffAmount As Integer
    Public Shared Property buffType As EnemyBuffType
    Public Shared Property buffBosses As Boolean

    Public Shared Property recruitment As RecruitmentType

    Public Shared Property shouldSaveChangelog As Boolean
    Public Shared Property changelogPath As String

    Private Class Settings
        Implements RecordKeeper.RecordableItem

        Public Function fieldTable() As Hashtable Implements RecordKeeper.RecordableItem.fieldTable
            Dim table As Hashtable = New Hashtable()

            table.Add("Randomize Growths", IIf(shouldRandomizeGrowths, "YES - Variance: " + growthsVariance.ToString + "% Minimum Growths? " + IIf(shouldForceMinimumGrowth, "YES", "NO") + " Weight HP Growths? " + IIf(shouldWeightHPGrowths, "YES", "NO"), "NO"))
            table.Add("Randomize Bases", IIf(shouldRandomizeBases, "YES - Variance: " + baseVariance.ToString, "NO"))
            table.Add("Randomize CON", IIf(shouldRandomizeCON, "YES - Minimum CON: " + minimumCON.ToString, "NO"))
            table.Add("Randomize MOV", IIf(shouldRandomizeMOV, "YES - Minimum MOV: " + minimumMOV.ToString + " Maximum MOV: " + maximumMOV.ToString, "NO"))
            table.Add("Randomize Affinity", IIf(shouldRandomizeAffinity, "YES", "NO"))
            table.Add("Randomize Items", IIf(shouldRandomizeItems, "YES - " + IIf(mightVariance > 0, "(Might Variance: " + mightVariance.ToString + " Minimum Might: " + minimumMight.ToString + ")", "") + IIf(hitVariance > 0, "(Hit Variance: " + hitVariance.ToString + " Minimum Hit: " + minimumHit.ToString + ")", "") + IIf(criticalVariance > 0, "(Critical Variance: " + criticalVariance.ToString + " Minimum Critical: " + minimumCritical.ToString + ")", "") + IIf(weightVariance > 0, "(Weight Variance: " + weightVariance.ToString + " Minimum Weight: " + minimumWeight.ToString + " Maximum Weight: " + maximumWeight.ToString + ")", "") + IIf(randomTraits, "(Assign Random Traits)", ""), "NO"))
            table.Add("Randomize Classes", IIf(shouldRandomizeClasses, "YES - " + IIf(randomLords, "(Randomize Lords)", "") + IIf(randomThieves, "(Randomize Thieves)", "") + IIf(randomBosses, "(Randomize Bosses)", "") + IIf(uniqueClasses, "(Unique Classes)", "") + IIf(crossgender, "(Cross Gender)", ""), "NO"))
            table.Add("Recruitment", IIf(recruitment = RecruitmentType.RecruitmentTypeNormal, "Normal", IIf(recruitment = RecruitmentType.RecruitmentTypeReverse, "Reverse", "Random")))
            table.Add("Buff Enemies", IIf(buffEnemies, "YES - Amount " + IIf(buffType = EnemyBuffType.BuffTypeSetConstant, "= ", "< ") + buffAmount.ToString + " " + IIf(buffBosses, "(Buff Bosses)", ""), "NO"))

            Return table
        End Function

        Public Function orderedKeys() As ArrayList Implements RecordKeeper.RecordableItem.orderedKeys
            Dim keyList As ArrayList = New ArrayList

            keyList.Add("Randomize Growths")
            keyList.Add("Randomize Bases")
            keyList.Add("Randomize CON")
            keyList.Add("Randomize MOV")
            keyList.Add("Randomize Affinity")
            keyList.Add("Randomize Items")
            keyList.Add("Randomize Classes")
            keyList.Add("Recruitment")
            keyList.Add("Buff Enemies")

            Return keyList
        End Function

        Public Function primaryKey() As String Implements RecordKeeper.RecordableItem.primaryKey
            Return Nothing
        End Function
    End Class

    Public Shared Function recordableItem() As RecordKeeper.RecordableItem
        Return New Settings
    End Function

End Class
