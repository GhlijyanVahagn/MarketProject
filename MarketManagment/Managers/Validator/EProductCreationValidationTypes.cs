using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Validator
{
    public enum EProductCreationValidationTypes:int
    {

        nameIsDublicated,
        codeIsDublicated,
        barCodeIsDublicated,
        producerIsMissing,
        unitIsMissing,
        groupIsMissing,
        sourceIsNull
    }
}
