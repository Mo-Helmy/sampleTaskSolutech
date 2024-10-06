using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.StoreServices.Dto;

public class MergeStoreSpaceCommandDto
{
    public int StoreId { get; set; }

    public int MergeSpaceId {  get; set; }
    public int MergeWithSpaceId {  get; set; }

}
