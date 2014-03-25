using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[3]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Weapon":
                    this.GetUnit(commandWords[2]).AddSupplement(new Weapon());
                    break;
                case "PowerInhibitor":
                    this.GetUnit(commandWords[2]).AddSupplement(new PowerInhibitor());
                    break;
                case "HealthInhibitor":
                    this.GetUnit(commandWords[2]).AddSupplement(new HealthInhibitor());
                    break;
                case "AggressionInhibitor":
                    this.GetUnit(commandWords[2]).AddSupplement(new AggressionInhibitor());
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    {
                        Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                        Unit sourceUnit = this.GetUnit(interaction.SourceUnit);

                        if (sourceUnit.UnitClassification ==
                            InfestationRequirements.RequiredClassificationToInfest(targetUnit.UnitClassification))
                        {
                            targetUnit.AddSupplement(new InfestationSpores());
                        }

                        break;
                    }
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
