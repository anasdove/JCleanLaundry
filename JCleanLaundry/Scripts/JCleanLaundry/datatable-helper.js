(function () {
    // Declare namespace
    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    // Data Table Helper Class
    window.jclean.web.dataTableHelper = function () {

        var loadTableClientSide = function (selector, dataSource, columnDefinition, pageLength, lengthMenu) {

            var _table = $(selector).DataTable({

                "responsive"    : true,                 // Responsive layout option, if set true so the table will be responsive
                "destroy"       : true,                 // Destroy instance if datatable call again, if set true so preventing error if the data table is called again
                "filter"        : true,                // Display search box, if set false so the textbox is disappeared
                "order"         : [[0, "asc"]],         // Default order on first load, Set 1st column to order ascendingly
                "data"          : dataSource,           // Set the datasource
                "columns"       : columnDefinition,     // Set column definition
                "pageLength"    : pageLength,           // Set the Page Length 
                "lengthMenu"    : lengthMenu,           // Set the list of Show Display Dropdown
                "scrollX"       : true,                 // Horizontal scrolling, if set true so if the width of table beyond the width of container, so the horizontal scroll bar will appear
                "language"      : false
            });
        }

        var loadTableClientSideWithoutURL = function (selector, dataSource, columnDefinition) {

            var _table = $(selector).DataTable({

                "responsive"    : true,                 // Responsive layout option, if set true so the table will be responsive
                "destroy"       : true,                 // Destroy instance if datatable call again, if set true so preventing error if the data table is called again
                "filter"        : false,                // Display search box, if set false so the textbox is disappeared
                "order"         : [[0, "asc"]],         // Default order on first load, Set 1st column to order ascendingly
                "data"          : dataSource,           // Set the datasource
                "columns"       : columnDefinition,     // Set column definition
                "scrollX"       : true,                 // Horizontal scrolling, if set true so if the width of table beyond the width of container, so the horizontal scroll bar will appear
                "bPaginate"     : false,
                "bLengthChange" : false,
                "bInfo"         : false,
                "language"      : {
                                      "lengthMenu": "Show _MENU_ entries per page"
                                  }
            });
        }

        return {
            "loadTableClientSide"           : loadTableClientSide,
            "loadTableClientSideWithoutURL" : loadTableClientSideWithoutURL
        }
    }
}());