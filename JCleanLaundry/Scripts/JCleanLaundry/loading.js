(function () {
    // Declare namespace
    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    // Loading Class (use to display loading icon when ajax calling)
    window.jclean.web.loading = function () {

        // Global Variable
        var _modalLoading = "div_modal-loading";

        // Initialize loading class
        var init = function (element) {

            // Append modal loading class (class="div_modal-loading) if that element not exist the class
            if (!($(element).children().attr("class") == _modalLoading)) {
                $(element).append("<div class=\"" + _modalLoading + "\"></div>");
            }

            // Trigger document
            $(document).on({
                // Add loading class (class="loading") in the element when ajax start event is fired
                ajaxStart: function () {
                    $(element).addClass("loading");
                },

                // Remove loading class (class="loading") in the element when ajax stop event is fired
                ajaxStop: function () {
                    $(element).removeClass("loading");
                }
            });
        }

        // Show Loading Icon
        var show = function (element) {
            $(element).append("<div class=\"" + _modalLoading + "\"></div>");
            $(element).addClass("loading");
        }

        // Mark specific method as public
        return {
            "init": init,
            "show": show
        }
    }
}());

