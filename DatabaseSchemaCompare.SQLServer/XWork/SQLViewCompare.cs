using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DatabaseSchemaCompare.SQLServer.XWork
{
    public class SQLViewCompare
    {
        public static void ExecuteNow(XModel.ProcessXSupport pxs)
        {
            // 뷰 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            var satsp = pxs.ViewList();
            var compareResult = satsp.Source.GroupJoin(
                satsp.Target,
                x => x.VIEW_NAME,
                y => y.VIEW_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            );
            // 타겟에 존재하는 뷰 - 즉 양쪽 다 있다
            var existViewList = compareResult.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 뷰 리스트
            var notExistViewList = compareResult.Where(x => (x.Target == null)).ToList();

            // 존재하지 않는 뷰만
            pxs.WriteReport(string.Empty);
            pxs.WriteReport("<<<<<<<<<< 존재하지 않는 뷰 >>>>>>>>>>");
            pxs.WriteReport(string.Join(Environment.NewLine, notExistViewList.Select(x => x.Source.Original.VIEW_NAME)));

            // CREATE VIEW 스키마 내보내기
            notExistViewList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    pxs,
                    new List<string>() { "VIEW", "CREATE" },
                    x.Source.Original.VIEW_NAME, 
                    x.Source.Original.VIEW_DEFINITION,
                    string.Empty
                )
            );

            // 존재하지만 다른 뷰
            pxs.WriteReport(string.Empty);
            pxs.WriteReport("<<<<<<<<<< 존재하지만 스키마가 다른 뷰 >>>>>>>>>>");
            pxs.WriteReport(string.Join(Environment.NewLine, existViewList.Select(x => x.Source.Original.VIEW_NAME)));

            // CREATE VIEW 스키마 내보내기
            existViewList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    pxs,
                    new List<string>() { "VIEW", "ALTER" },
                    x.Source.Original.VIEW_NAME, 
                    x.Source.Original.VIEW_DEFINITION,
                    x.Target.Original.VIEW_DEFINITION
                )
            );
        }
    }
}
