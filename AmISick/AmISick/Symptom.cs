using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmISick
{
    enum Symptom
    {
        //string enumText = ((Coolness)1).ToString() - взимане на името на enum
        [Display(Name = "Runny nose")]
        RunnyNose,
        [Display(Name = "Sore throat")]
        SoreThroat,
        [Display(Name = "Headache")]
        Headache,
        [Display(Name = "Coughing")]
        Coughing,
        [Display(Name = "Sneezing")]
        Sneezing,
        [Display(Name = "Muscle aches")]
        MuscleAches,
        [Display(Name = "Vomiting")]
        Vomiting,
        [Display(Name = "Тrouble breathing")]
        TroubleBreathing,
        [Display(Name = "Loss of taste or smell")]
        LossOfTasteSmell,
        [Display(Name = "Stomach pain")]
        StomachPain
    }
}
