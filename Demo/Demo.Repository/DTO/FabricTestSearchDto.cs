using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.DTO
{
    public class FabricTestSearchDto : Paging
    {
        public SortColumn SortColumn { get; set; }
        public FabricTestModel Data { get; set; }
        public int UserId { get; set; }
    }

    public class FabricTestModel
    {
        public string FileNo { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int FabricInfoId { get; set; }
        public DateTime? DeadlineFrom { get; set; }
        public DateTime? DeadlineTo { get; set; }
        public int? Supplier { get; set; }
        public string RequestBy { get; set; }
        public int? TestResultTo { get; set; }
        public string TestResult { get; set; }
        public int? Status { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    public class FabricTestResultDto
    {
        public int Id { get; set; }
        public int? FabricTestResultReportId { get; set; }
        public int? FabricInfoId { get; set; }
        public int LabRoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public int? FabricTestTypeId { get; set; }
        public int FabricSampleLogsPageId { get; set; }
        public int? FabricSampleOrderId { get; set; }
        public int? QualityAgreementId { get; set; }
        public string FileNo { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? Deadline { get; set; }
        public string Supplier { get; set; }
        public int SupplierId { get; set; }
        public int FabricSupplierId { get; set; }
        public string RequestBy { get; set; }
        public string TestResultTo { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public int? Status { get; set; }
        public string StatusName { get; set; }
        public string Color { get; set; }
        public string Composition { get; set; }
        public string Weight { get; set; }
        public string Width { get; set; }
        public string Description { get; set; }
        public string ArtNo { get; set; }
        public string PersonInCharge { get; set; } //Lab guy do the test
        public FabricPersonInchargeDto PersonInChargeUser { get; set; }
        public int? PersonInChargeUserId { get; set; }
        public int TotalCheckmark { get; set; }
        public bool IsHasResult { get; set; }
        public string StorageLocation { get; set; }
        public DateTime Created { get; set; }

        public List<int> SelectedResultTo { get; set; }
    }

    public class FabricTestSearchResult
    {
        public int TotalRecords { get; set; }
        public List<FabricTestResultDto> Records { get; set; }
    }

    public class FabricPersonInchargeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
