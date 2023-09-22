using QualifactChallenge.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifactChallenge.ApplicationLayer.Services.Interfaces
{
    public interface IDivisivilityService
    {
        Task<List<DTODivisivility>> GetResultsAsync(int input1, int input2, int sampleSize);
    }
}
