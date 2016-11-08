(function () {
    // Declare namespace
    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    // Data Table Helper Class
    window.jclean.web.dataTableHelper = function () {

        // Initialize Data Table Server Side
        var init = function (selector, url, param, pageLength, columnDefinition, lengthMenu) {
            // Initialize the Data Table (using jQuery DataTable)
            var _table = $(selector).DataTable({
                "responsive": true,                             // Responsive layout option, if set true so the table will be responsive
                "destroy": true,                             // Destroy instance if datatable call again, if set true so preventing error if the data table is called again
                "filter": false,                            // Display search box, if set false so the textbox is disappeared
                "pagingType": "simple_numbers",                 // Paging type => For pagination template
                "orderClasses": false,                            // Order class option (TODO: Find the purpose)
                "order": [[0, "asc"]],                     // Default order on first load, Set 1st column to order ascendingly
                "info": true,                             // Info total record, if set true so the Total Records information will be displayed
                "scrollX": true,                             // Horizontal scrolling, if set true so if the width of table beyond the width of container, so the horizontal scroll bar will appear
                "scrollCollapse": false,                            // Scrolling collapse (TODO: Find the purpose)
                "bProcessing": true,                             // If set true, so the text "processing" will displayed when system is being processing
                "bServerSide": true,                             // If set true, so the datatable is proceed server side
                "sAjaxSource": url,                              // Set the URL of Server Side (Calling Controller)
                "pageLength": pageLength,                       // Set the Page Length
                "lengthMenu": lengthMenu,                       // Set the list of Show Display Dropdown
                "columns": columnDefinition,                 // Set Columns Header

                /// Define method when datatable is initialized, sorting on certain column, pagination feature, and show display dropdown.
                /// <param name="searchItemURL" type="string">Search Item URL</param>
                /// <param name="defaultParam" type="JSON Array">Default Parameter pose by Data Table</param>
                /// <param name="fnCallback" type="Method">This method will be executed when data table is sucessfully proceed</param>
                "fnServerData": function (searchItemURL, defaultParam, fnCallback) {

                    // Concatenate default parameter from data table with custom parameter from Filter By Criteria
                    var customParam = defaultParam.concat(param);

                    // AJAX Call
                    $.ajax({
                        "dataType": "json",
                        "contentType": "application/json; charset=utf-8",
                        "type": "GET",
                        "url": searchItemURL,
                        "data": customParam,
                        /// <param name="returnData" type="DataTableBaseResponse Object">Return DataTableBaseResponse from Server</param>
                        "success": function (returnData) {

                            // Process data by datatable
                            fnCallback(returnData);

                            // Determine Length Menu wording
                            var lengthMenuText;
                            if (returnData.TotalData > returnData.recordsTotal) {
                                lengthMenuText = "entries per page (showing " + returnData.recordsTotal + " of " + returnData.TotalData + " entries)";
                            } else {
                                lengthMenuText = "entries per page";
                            }

                            // Append wording for length menu
                            $("span#span-dataTables_length").text(lengthMenuText);
                        },

                        // Handle if error occured
                        "error": function (xhr, textStatus, error) {
                            if (typeof console == "object") {
                                // TODO: Add Logging to log if DataTable is failed to render the table
                                console.log(xhr.status + "," + xhr.responseText + "," + textStatus + "," + error);
                            }
                        }
                    });
                },
                "language": {
                    "lengthMenu": "Show _MENU_ <span id=\"span-dataTables_length\"></span>"
                },
            });
        }

        // Initialize Data Table Client Side
        var initClientSide = function (url, param, selector, columnDefinition, pageLength, lengthMenu) {

            // Generate Table From URL
            _generateTableClientSideFromUrl(url, param, selector, columnDefinition, pageLength, lengthMenu);
        }

        // Load Table
        var _loadTableClientSide = function (selector, dataSource, columnDefinition, pageLength, lengthMenu) {
            // Initialize the Data Table (using jQuery DataTable)
            var _table = $(selector).DataTable({
                "responsive": true,                 // Responsive layout option, if set true so the table will be responsive
                "destroy": true,                 // Destroy instance if datatable call again, if set true so preventing error if the data table is called again
                "filter": false,                // Display search box, if set false so the textbox is disappeared
                "order": [[0, "asc"]],         // Default order on first load, Set 1st column to order ascendingly
                "data": dataSource,           // Set the datasource
                "columns": columnDefinition,     // Set column definition
                "pageLength": pageLength,           // Set the Page Length 
                "lengthMenu": lengthMenu,           // Set the list of Show Display Dropdown
                "scrollX": true,                  // Horizontal scrolling, if set true so if the width of table beyond the width of container, so the horizontal scroll bar will appear
                "language": {
                    "lengthMenu": "Show _MENU_ entries per page"
                }
            });
        }

        // Load Table
        var loadTableClientSideWithoutURL = function (selector, dataSource, columnDefinition) {
            // Initialize the Data Table (using jQuery DataTable)
            var _table = $(selector).DataTable({
                "responsive": true,                 // Responsive layout option, if set true so the table will be responsive
                "destroy": true,                 // Destroy instance if datatable call again, if set true so preventing error if the data table is called again
                "filter": false,                // Display search box, if set false so the textbox is disappeared
                "order": [[0, "asc"]],         // Default order on first load, Set 1st column to order ascendingly
                "data": dataSource,           // Set the datasource
                "columns": columnDefinition,     // Set column definition
                "scrollX": true,                  // Horizontal scrolling, if set true so if the width of table beyond the width of container, so the horizontal scroll bar will appear
                "bPaginate": false,
                "bLengthChange": false,
                "bInfo": false,
                "language": {
                    "lengthMenu": "Show _MENU_ entries per page"
                }
            });
        }

        // Generate Table From URL
        var _generateTableClientSideFromUrl = function (url, param, selector, columnDefinition, pageLength, lengthMenu) {
            var ajaxOptions = {
                url: url,
                type: "GET",
                cache: false,
                data: param,
                success: function (returnValue) {
                    // returnValue should have format 2 multi dimensional arry
                    _loadTableClientSide(selector, returnValue, columnDefinition, pageLength, lengthMenu);
                }
            };

            $.ajax(ajaxOptions);
        }

        // Mark specific method as public
        return {
            "init": init,
            "initClientSide": initClientSide,
            "loadTableClientSideWithoutURL": loadTableClientSideWithoutURL
        }
    }
}());