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

        Public Function stringDescription() As String Implements RecordKeeper.RecordableItem.stringDescription
            Return "Randomize Growths? " + IIf(shouldRandomizeGrowths, "YES - Variance: " + growthsVariance.ToString + "% Minimum Growths? " + IIf(shouldForceMinimumGrowth, "YES", "NO") + " Weight HP Growths? " + IIf(shouldWeightHPGrowths, "YES", "NO"), "NO") + vbCrLf _
                & "Randomize Bases? " + IIf(shouldRandomizeBases, "YES - Variance: " + baseVariance.ToString, "NO") + vbCrLf _
                & "Randomize CON? " + IIf(shouldRandomizeCON, "YES - Minimum CON: " + minimumCON.ToString, "NO") + vbCrLf _
                & "Randomize MOV? " + IIf(shouldRandomizeMOV, "YES - Minimum MOV: " + minimumMOV.ToString + " Maximum MOV: " + maximumMOV.ToString, "NO") + vbCrLf _
                & "Randomize Affinity? " + IIf(shouldRandomizeAffinity, "YES", "NO") + vbCrLf _
                & "Randomize Items? " + IIf(shouldRandomizeItems, "YES - " + IIf(mightVariance > 0, "(Might Variance: " + mightVariance.ToString + " Minimum Might: " + minimumMight.ToString + ")", "") + IIf(hitVariance > 0, "(Hit Variance: " + hitVariance.ToString + " Minimum Hit: " + minimumHit.ToString + ")", "") + IIf(criticalVariance > 0, "(Critical Variance: " + criticalVariance.ToString + " Minimum Critical: " + minimumCritical.ToString + ")", "") + IIf(weightVariance > 0, "(Weight Variance: " + weightVariance.ToString + " Minimum Weight: " + minimumWeight.ToString + " Maximum Weight: " + maximumWeight.ToString + ")", "") + IIf(randomTraits, "(Assign Random Traits)", ""), "NO") + vbCrLf _
                & "Randomize Classes? " + IIf(shouldRandomizeClasses, "YES - Amount " + IIf(randomLords, "(Randomize Lords)", "") + IIf(randomThieves, "(Randomize Thieves)", "") + IIf(randomBosses, "(Randomize Bosses)", "") + IIf(uniqueClasses, "(Unique Classes)", "") + IIf(crossgender, "(Cross Gender)", ""), "NO") + vbCrLf _
                & "Recruitment? " + IIf(recruitment = RecruitmentType.RecruitmentTypeNormal, "Normal", IIf(recruitment = RecruitmentType.RecruitmentTypeReverse, "Reverse", "Random")) + vbCrLf _
                & "Buff Enemies? " + IIf(buffEnemies, "YES - " + IIf(buffType = EnemyBuffType.BuffTypeSetConstant, "= ", "< ") + buffAmount.ToString + " " + IIf(buffBosses, "(Buff Bosses)", ""), "NO") + vbCrLf
        End Function
    End Class

    Public Shared Function recordableItem() As RecordKeeper.RecordableItem
        Return New Settings
    End Function

End Class
