/*
Template Name: Minton - Admin & Dashboard Template
Author: CoderThemes
Version: 1.0.0
Website: https://coderthemes.com/
Contact: support@coderthemes.com
File: Layouts Js File
*/


/**
 * LeftSidebar
 * @param {*} $ 
 */
easeInOutQuad = function (t, b, c, d) {
    t /= d / 2;
    if (t < 1) return c / 2 * t * t + b;
    t--;
    return -c / 2 * (t * (t - 2) - 1) + b;
};

scrollTo = function (element, to, duration) {
    var start = element.scrollTop, change = to - start, currentTime = 0, increment = 20;
    var animateScroll = function () {
        currentTime += increment;
        var val = easeInOutQuad(currentTime, start, change, duration);
        element.scrollTop = val;
        if (currentTime < duration) {
            setTimeout(animateScroll, increment);
        }
    };
    animateScroll();
}


!function ($) {
    'use strict';

    var LeftSidebar = function () {
        this.body = $('body'),
            this.window = $(window)
    };

    /**
     * Reset the theme
     */
    LeftSidebar.prototype._reset = function () {
        this.body.removeAttr('data-sidebar-color');
        this.body.removeAttr('data-sidebar-size');
        this.body.removeAttr('data-sidebar-showuser');
    },

        /**
         * Changes the color of sidebar
         * @param {*} color 
         */
        LeftSidebar.prototype.changeColor = function (color) {
            this.body.attr('data-sidebar-color', color);
            this.parent.updateConfig("sidebar", { "color": color });
        },

        /**
         * Changes the size of sidebar
         * @param {*} size 
         */
        LeftSidebar.prototype.changeSize = function (size) {
            this.body.attr('data-sidebar-size', size);
            this.parent.updateConfig("sidebar", { "size": size });
        },

        /**
         * Toggle User information
         * @param {*} showUser 
         */
        LeftSidebar.prototype.showUser = function (showUser) {
            this.body.attr('data-sidebar-showuser', showUser);
            this.parent.updateConfig("sidebar", { "showuser": showUser });
        },

        /**
         * Initilizes the menu
         */
        LeftSidebar.prototype.initMenu = function () {
            var self = this;

            var layout = $.LayoutThemeApp.getConfig();
            var sidebar = $.extend({}, layout ? layout.sidebar : {});
            var defaultSidebarSize = sidebar.size ? sidebar.size : 'default';

            // resets everything
            this._reset();

            // Left menu collapse
            $('.button-menu-mobile').on('click', function (event) {
                event.preventDefault();
                var sidebarSize = self.body.attr('data-sidebar-size');
                if (self.window.width() >= 993) {
                    if (sidebarSize === 'condensed') {
                        self.changeSize(defaultSidebarSize === 'condensed' ? 'default' : defaultSidebarSize);
                    } else {
                        self.changeSize('condensed');
                    }
                } else {
                    self.changeSize(defaultSidebarSize);
                    self.body.toggleClass('sidebar-enable');
                }
            });

            // sidebar - main menu
            if ($("#side-menu").length) {
                var navCollapse = $('#side-menu li .collapse');
                var navToggle = $("#side-menu [data-bs-toggle='collapse']");
                navToggle.on('click', function (e) {
                    return false;
                });
                // open one menu at a time only

                navCollapse.on({
                    'show.bs.collapse': function (event) {
                        $('#side-menu .collapse.show').not(parent).collapse('hide');
                        var parent = $(event.target).parents('.collapse.show');
                    },
                });


                // activate the menu in left side bar (Vertical Menu) based on url
                $("#side-menu a").each(function () {
                    var pageUrl = window.location.href.split(/[?#]/)[0];
                    if (this.href == pageUrl) {
                        $(this).addClass("active");
                        $(this).parent().addClass("menuitem-active");
                        $(this).parent().parent().parent().addClass("show");
                        $(this).parent().parent().parent().parent().addClass("menuitem-active"); // add active to li of the current link

                        var firstLevelParent = $(this).parent().parent().parent().parent().parent().parent();
                        if (firstLevelParent.attr('id') !== 'sidebar-menu')
                            firstLevelParent.addClass("show");

                        $(this).parent().parent().parent().parent().parent().parent().parent().addClass("menuitem-active");

                        var secondLevelParent = $(this).parent().parent().parent().parent().parent().parent().parent().parent().parent();
                        if (secondLevelParent.attr('id') !== 'wrapper')
                            secondLevelParent.addClass("show");

                        var upperLevelParent = $(this).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent();
                        if (!upperLevelParent.is('body'))
                            upperLevelParent.addClass("menuitem-active");
                    }
                });
            }


            // handling two columns menu if present
            var twoColSideNav = $("#two-col-sidenav-main");
            if (twoColSideNav.length) {
                var twoColSideNavItems = $("#two-col-sidenav-main .nav-link");
                var sideSubMenus = $(".twocolumn-menu-item");

                // showing/displaying tooltip based on screen size
                if (this.window.width() >= 585) {
                    //TODO : Wait for stable release of bootstrap 5
                    // twoColSideNavItems.each(function (idx,element){
                    //    new bootstrap.Tooltip(element);
                    // });
                } else {
                    // twoColSideNavItems.tooltip('disable');
                }

                var nav = $('.twocolumn-menu-item .nav-second-level');
                var navCollapse = $('#two-col-menu li .collapse');

                // open one menu at a time only
                navCollapse.on({
                    'show.bs.collapse': function () {
                        var nearestNav = $(this).closest(nav).closest(nav).find(navCollapse);
                        if (nearestNav.length)
                            nearestNav.not($(this)).collapse('hide');
                        else
                            navCollapse.not($(this)).collapse('hide');
                    }
                });



                twoColSideNavItems.on('click', function (e) {
                    var target = $($(this).attr('href'));

                    if (target.length) {
                        e.preventDefault();

                        twoColSideNavItems.removeClass('active');
                        $(this).addClass('active');

                        sideSubMenus.removeClass("d-block");
                        target.addClass("d-block");

                        // showing full sidebar if menu item is clicked
                        $.LayoutThemeApp.leftSidebar.changeSize('default');
                        return false;
                    }
                    return true;
                });

                // activate menu with no child
                var pageUrl = window.location.href.split(/[?#]/)[0];
                twoColSideNavItems.each(function () {
                    if (this.href == pageUrl) {
                        $(this).addClass('active');
                    }
                });



                // activate the menu in left side bar (Two column) based on url
                $("#two-col-menu a").each(function () {
                    if (this.href == pageUrl) {
                        $(this).addClass("active");
                        $(this).parent().addClass("menuitem-active");
                        $(this).parent().parent().parent().addClass("show");
                        $(this).parent().parent().parent().parent().addClass("menuitem-active"); // add active to li of the current link

                        var firstLevelParent = $(this).parent().parent().parent().parent().parent().parent();
                        if (firstLevelParent.attr('id') !== 'sidebar-menu')
                            firstLevelParent.addClass("show");

                        $(this).parent().parent().parent().parent().parent().parent().parent().addClass("menuitem-active");

                        var secondLevelParent = $(this).parent().parent().parent().parent().parent().parent().parent().parent().parent();
                        if (secondLevelParent.attr('id') !== 'wrapper')
                            secondLevelParent.addClass("show");

                        var upperLevelParent = $(this).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent();
                        if (!upperLevelParent.is('body'))
                            upperLevelParent.addClass("menuitem-active");

                        // opening menu
                        var matchingItem = null;
                        var targetEl = '#' + $(this).parents('.twocolumn-menu-item').attr("id");
                        $("#two-col-sidenav-main .nav-link").each(function () {
                            if ($(this).attr('href') === targetEl) {
                                matchingItem = $(this);
                            }
                        });
                        if (matchingItem) matchingItem.trigger('click');
                    }
                });
            }
        },


        /**
         * Initilize the left sidebar size based on screen size
         */
        LeftSidebar.prototype.initLayout = function () {
            var self = this;
            // in case of small size, activate the small menu
            if ((this.window.width() >= 768 && this.window.width() <= 1199) || this.body.data('keep-enlarged')) {
                this.changeSize('condensed');
            } else {
                var layout = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');
                var sidebar = $.extend({}, layout ? layout.sidebar : {});
                var defaultSidebarSize = sidebar && sidebar.size ? sidebar.size : 'default';
                var sidebarSize = self.body.attr('data-sidebar-size');
                this.changeSize(defaultSidebarSize ? defaultSidebarSize : (sidebarSize ? sidebarSize : 'default'));
            }
        },

        /**
         * Initilizes the menu
         */
        LeftSidebar.prototype.init = function () {
            var self = this;
            this.initMenu();
            this.initLayout();

            // on window resize, make menu flipped automatically
            this.window.on('resize', function (e) {
                e.preventDefault();
                self.initLayout();
            });
        },

        $.LeftSidebar = new LeftSidebar, $.LeftSidebar.Constructor = LeftSidebar
}(window.jQuery),


    /**
     * Topbar
     * @param {*} $ 
     */
    function ($) {
        'use strict';

        var Topbar = function () {
            this.body = $('body'),
                this.window = $(window)
        };

        /**
         * Initilizes the menu
         */
        Topbar.prototype.initMenu = function () {
            // Serach Toggle
            $('#top-search').on('click', function (e) {
                $('#search-dropdown').addClass('d-block');
            });

            // hide search on opening other dropdown
            $('.topbar-dropdown').on('show.bs.dropdown', function () {
                $('#search-dropdown').removeClass('d-block');
            });

            //activate the menu in topbar(horizontal menu) based on url
            $(".navbar-nav a").each(function () {
                var pageUrl = window.location.href.split(/[?#]/)[0];
                if (this.href == pageUrl) {
                    $(this).addClass("active");
                    $(this).parent().addClass("active");
                    $(this).parent().parent().addClass("active");
                    $(this).parent().parent().parent().addClass("active");
                    $(this).parent().parent().parent().parent().addClass("active");
                    var el = $(this).parent().parent().parent().parent().addClass("active").prev();
                    if (el.hasClass("nav-link"))
                        el.addClass('active');
                }
            });

            setTimeout(function () {
                var activatedItem = document.querySelector('li.menuitem-active .active');
                if (activatedItem != null) {
                    var simplebarContent = document.querySelector('.left-side-menu .simplebar-content-wrapper');
                    var offset = activatedItem.offsetTop - 300;
                    if (simplebarContent && offset > 100) {
                        scrollTo(simplebarContent, offset, 600);
                    }
                }
            }, 200);



            // Topbar - main menu
            $('.navbar-toggle').on('click', function (event) {
                $(this).toggleClass('open');
                $('#navigation').slideToggle(400);
            });
        },

            /**
             * Changes the color of topbar
             * @param {*} color 
             */
            Topbar.prototype.changeColor = function (color) {
                this.body.attr('data-topbar-color', color);
                this.parent.updateConfig("topbar", { "color": color });
            },

            /**
             * Initilizes the menu
             */
            Topbar.prototype.init = function () {
                this.initMenu();
            },
            $.Topbar = new Topbar, $.Topbar.Constructor = Topbar
    }(window.jQuery),


    /**
     * RightBar
     * @param {*} $ 
     */
    function ($) {
        'use strict';

        var RightBar = function () {
            this.body = $('body'),
                this.window = $(window)
        };

        /** 
         * Select the option based on saved config
        */
        RightBar.prototype.selectOptionsFromConfig = function () {
            var self = this;

            var config = self.layout.getConfig();

            if (config) {
                $('.right-bar input[type=checkbox]').prop('checked', false);
                $('input[type=checkbox][name=color-scheme-mode][value=' + config.mode + ']').prop('checked', true);
                $('input[type=checkbox][name=width][value=' + config.width + ']').prop('checked', true);
                $('input[type=checkbox][name=menus-position][value=' + config.menuPosition + ']').prop('checked', true);

                $('input[type=checkbox][name=leftsidebar-color][value=' + config.sidebar.color + ']').prop('checked', true);
                $('input[type=checkbox][name=leftsidebar-size][value=' + config.sidebar.size + ']').prop('checked', true);
                $('input[type=checkbox][name=leftsidebar-user]').prop('checked', config.sidebar.showuser);

                $('input[type=checkbox][name=topbar-color][value=' + config.topbar.color + ']').prop('checked', true);
            }
        },

            /**
             * Toggles the right sidebar
             */
            RightBar.prototype.toggleRightSideBar = function () {
                var self = this;
                self.body.toggleClass('right-bar-enabled');
                self.selectOptionsFromConfig();
            },

            /**
             * Initilizes the right side bar
             */
            RightBar.prototype.init = function () {
                var self = this;

                // right side-bar toggle
                $(document).on('click', '.right-bar-toggle', function () {
                    self.toggleRightSideBar();
                });

                $(document).on('click', 'body', function (e) {
                    // hiding search bar
                    if ($(e.target).closest('#top-search').length !== 1) {
                        $('#search-dropdown').removeClass('d-block');
                    }
                    if ($(e.target).closest('.right-bar-toggle, .right-bar').length > 0) {
                        return;
                    }

                    if ($(e.target).closest('.left-side-menu, .side-nav').length > 0 || $(e.target).hasClass('button-menu-mobile')
                        || $(e.target).closest('.button-menu-mobile').length > 0) {
                        return;
                    }

                    $('body').removeClass('right-bar-enabled');
                    $('body').removeClass('sidebar-enable');
                    return;
                });

                // overall color scheme
                $('input[type=checkbox][name=color-scheme-mode]').change(function () {
                    self.layout.changeMode($(this).val());
                    self.selectOptionsFromConfig();

                });

                // width mode
                $('input[type=checkbox][name=width]').change(function () {
                    self.layout.changeLayoutWidth($(this).val());
                    self.selectOptionsFromConfig();
                });

                // menus-position
                $('input[type=checkbox][name=menus-position]').change(function () {
                    self.layout.changeMenuPositions($(this).val());
                    self.selectOptionsFromConfig();

                });

                // left sidebar color
                $('input[type=checkbox][name=leftsidebar-color]').change(function () {
                    self.layout.leftSidebar.changeColor($(this).val());
                    self.selectOptionsFromConfig();

                });

                // left sidebar size
                $('input[type=checkbox][name=leftsidebar-size]').change(function () {
                    self.layout.leftSidebar.changeSize($(this).val());
                    self.selectOptionsFromConfig();

                });

                // left sidebar user information
                $('input[type=checkbox][name=leftsidebar-user]').change(function (e) {
                    self.layout.leftSidebar.showUser(e.target.checked);
                    self.selectOptionsFromConfig();

                });

                // topbar
                $('input[type=checkbox][name=topbar-color]').change(function () {
                    self.layout.topbar.changeColor($(this).val());
                    self.selectOptionsFromConfig();

                });

                // reset
                $('#resetBtn').on('click', function (e) {
                    e.preventDefault();
                    // reset to default
                    self.layout.reset();
                    self.selectOptionsFromConfig();
                });
            },

            $.RightBar = new RightBar, $.RightBar.Constructor = RightBar
    }(window.jQuery),


    /**
     * Layout and theme manager
     * @param {*} $ 
     */

    function ($) {
        'use strict';

        // Layout and theme manager

        var LayoutThemeApp = function () {
            this.body = $('body'),
                this.window = $(window),
                this.config = {},
                // styles
                this.defaultBSStyle = $("#bs-stylesheet"),
                this.defaultAppStyle = $("#app-stylesheet");
        };

        /**
        * Preserves the config in memory
        */
        LayoutThemeApp.prototype._saveConfig = function (newConfig) {
            this.config = $.extend(this.config, newConfig);
            // NOTE: You can make ajax call here to save preference on server side or localstorage as well

        },

            /**
             * Update the config for given config
             * @param {*} param 
             * @param {*} config 
             */
            LayoutThemeApp.prototype.updateConfig = function (param, config) {
                var newObj = {};


                if (typeof config === 'object' && config !== null) {
                    var originalParam = this.config[param];
                    newObj[param] = $.extend(originalParam, config);
                } else {
                    newObj[param] = config;
                }
                this._saveConfig(newObj);

            }

        /**
         * Loads the config - takes from body if available else uses default one
         */
        LayoutThemeApp.prototype.loadConfig = function () {
            var bodyConfig = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');

            var config = $.extend({}, {
                mode: "light",
                width: "fluid",
                menuPosition: 'fixed',
                sidebar: {
                    color: "light",
                    size: "default",
                    showuser: false
                },
                topbar: {
                    color: "dark"
                },
                showRightSidebarOnPageLoad: false
            });
            if (bodyConfig) {
                config = $.extend({}, config, bodyConfig);
            };
            return config;
        },

            /**
            * Apply the config
            */
            LayoutThemeApp.prototype.applyConfig = function () {
                // getting the saved config if available
                this.config = this.loadConfig();
                var topbarConfig = $.extend({}, this.config.topbar);
                var sidebarConfig = $.extend({}, this.config.sidebar);

                // activate menus
                this.leftSidebar.init();
                this.topbar.init();

                this.leftSidebar.parent = this;
                this.topbar.parent = this;


                // mode
                this.changeMode(this.config.mode);

                // width
                this.changeLayoutWidth(this.config.width);

                // menu position
                this.changeMenuPositions(this.config.menuPosition);

                // left sidebar
                this.leftSidebar.changeColor(sidebarConfig.color);
                this.leftSidebar.changeSize(sidebarConfig.size);
                this.leftSidebar.showUser(sidebarConfig.showuser);

                // topbar
                this.topbar.changeColor(topbarConfig.color);
            },

            /**
             * Toggle dark or light mode
             * @param {*} mode 
             */
            LayoutThemeApp.prototype.changeMode = function (mode, notChangeSidebar) {
                // sets the theme
                switch (mode) {
                    case "dark": {
                        if (document.getElementById('bs-stylesheet').href.includes('rtl.min.css')) {
                            this.defaultBSStyle.attr('href', 'assets/css/bootstrap-dark-rtl.min.css');
                            this.defaultAppStyle.attr('href', 'assets/css/app-dark-rtl.min.css');
                        }
                        else {
                            this.defaultBSStyle.attr('href', 'assets/css/bootstrap-dark.min.css');
                            this.defaultAppStyle.attr('href', 'assets/css/app-dark.min.css');
                        }

                        if (notChangeSidebar)
                            this._saveConfig({ mode: mode });
                        else {
                            this.leftSidebar.changeColor("dark");
                            this._saveConfig({ mode: mode, sidebar: $.extend({}, this.config.sidebar, { color: 'dark' }) });
                        }
                        break;
                    }
                    default: {

                        if (document.getElementById('bs-stylesheet').href.includes('rtl.min.css')) {
                            this.defaultBSStyle.attr('href', 'assets/css/bootstrap-rtl.min.css');
                            this.defaultAppStyle.attr('href', 'assets/css/app-rtl.min.css');
                        }
                        else {
                            this.defaultBSStyle.attr('href', 'assets/css/bootstrap.min.css');
                            this.defaultAppStyle.attr('href', 'assets/css/app.min.css');
                        }

                        if (notChangeSidebar)
                            this._saveConfig({ mode: mode });
                        else {
                            this.leftSidebar.changeColor("light");
                            this._saveConfig({ mode: mode, sidebar: $.extend({}, this.config.sidebar, { color: 'light' }) });
                        }
                        break;
                    }
                }

                this.rightBar.selectOptionsFromConfig();
            }

        /**
         * Changes the width of layout
         */
        LayoutThemeApp.prototype.changeLayoutWidth = function (width) {
            switch (width) {
                case "boxed": {
                    this.body.attr('data-layout-width', 'boxed');
                    // automatically activating condensed
                    $.LeftSidebar.changeSize("condensed");
                    this._saveConfig({ width: width });
                    break;
                }
                default: {
                    this.body.attr('data-layout-width', 'fluid');
                    // automatically activating provided size
                    var bodyConfig = JSON.parse(this.body.attr('data-layout') ? this.body.attr('data-layout') : '{}');
                    $.LeftSidebar.changeSize(bodyConfig && bodyConfig.sidebar ? bodyConfig.sidebar.size : "default");
                    this._saveConfig({ width: width });
                    break;
                }
            }
            this.rightBar.selectOptionsFromConfig();
        }

        /**
         * Changes menu positions
         */
        LayoutThemeApp.prototype.changeMenuPositions = function (position) {
            this.body.attr("data-layout-menu-position", position);
            this.updateConfig("menuPosition", position);

        }

        /**
         * Clear out the saved config
         */
        LayoutThemeApp.prototype.clearSavedConfig = function () {
            this.config = {};
        },

            /**
             * Gets the config
             */
            LayoutThemeApp.prototype.getConfig = function () {
                return this.config;
            },

            /**
             * Reset to default
             */
            LayoutThemeApp.prototype.reset = function () {
                this.clearSavedConfig();
                this.applyConfig();
            },

            /**
             * Init
             */
            LayoutThemeApp.prototype.init = function () {
                this.leftSidebar = $.LeftSidebar;
                this.topbar = $.Topbar;

                this.leftSidebar.parent = this;
                this.topbar.parent = this;

                // initilize the menu
                this.applyConfig();
            },

            $.LayoutThemeApp = new LayoutThemeApp, $.LayoutThemeApp.Constructor = LayoutThemeApp
    }(window.jQuery);
/*
Template Name: Minton - Admin & Dashboard Template
Author: CoderThemes
Version: 1.0.0
Website: https://coderthemes.com/
Contact: support@coderthemes.com
File: Main Js File
*/


!function ($) {
    "use strict";

    var Components = function () { };

    //initializing tooltip
    Components.prototype.initTooltipPlugin = function () {
        $.fn.tooltip && $('[data-bs-toggle="tooltip"]').tooltip()
    },

    //initializing popover
    Components.prototype.initPopoverPlugin = function () {
        $.fn.popover && $('[data-bs-toggle="popover"]').popover()
    },

    //initializing toast
    Components.prototype.initToastPlugin = function() {
        $.fn.toast && $('[data-bs-toggle="toast"]').toast()
    },

    //initializing form validation
    Components.prototype.initFormValidation = function () {
        $(".needs-validation").on('submit', function (event) {
            $(this).addClass('was-validated');
            if ($(this)[0].checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
                return false;
            }
            return true;
        });
    },

    // Counterup
    Components.prototype.initCounterUp = function() {
        var delay = $(this).attr('data-delay')?$(this).attr('data-delay'):100; //default is 100
        var time = $(this).attr('data-time')?$(this).attr('data-time'):1200; //default is 1200
         $('[data-plugin="counterup"]').each(function(idx, obj) {
            $(this).counterUp({
                delay: delay,
                time: time
            });
         });
    },

    //peity charts
    Components.prototype.initPeityCharts = function() {
        $('[data-plugin="peity-pie"]').each(function(idx, obj) {
            var colors = $(this).attr('data-colors')?$(this).attr('data-colors').split(","):[];
            var width = $(this).attr('data-width')?$(this).attr('data-width'):20; //default is 20
            var height = $(this).attr('data-height')?$(this).attr('data-height'):20; //default is 20
            $(this).peity("pie", {
                fill: colors,
                width: width,
                height: height
            });
        });
        //donut
         $('[data-plugin="peity-donut"]').each(function(idx, obj) {
            var colors = $(this).attr('data-colors')?$(this).attr('data-colors').split(","):[];
            var width = $(this).attr('data-width')?$(this).attr('data-width'):20; //default is 20
            var height = $(this).attr('data-height')?$(this).attr('data-height'):20; //default is 20
            $(this).peity("donut", {
                fill: colors,
                width: width,
                height: height
            });
        });

        $('[data-plugin="peity-donut-alt"]').each(function(idx, obj) {
            $(this).peity("donut");
        });

        // line
        $('[data-plugin="peity-line"]').each(function(idx, obj) {
            $(this).peity("line", $(this).data());
        });

        // bar
        $('[data-plugin="peity-bar"]').each(function(idx, obj) {
            var colors = $(this).attr('data-colors')?$(this).attr('data-colors').split(","):[];
            var width = $(this).attr('data-width')?$(this).attr('data-width'):20; //default is 20
            var height = $(this).attr('data-height')?$(this).attr('data-height'):20; //default is 20
            $(this).peity("bar", {
                fill: colors,
                width: width,
                height: height
            });
         });
    },

    Components.prototype.initKnob = function() {
        $('[data-plugin="knob"]').each(function(idx, obj) {
           $(this).knob();
        });
    },

    Components.prototype.initTippyTooltips = function () {
        if($('[data-plugin="tippy"]').length > 0)
        tippy('[data-plugin="tippy"]');
    },

    Components.prototype.initShowPassword = function () {
        $("[data-password]").on('click', function() {
            if($(this).attr('data-password') == "false"){
                $(this).siblings("input").attr("type", "text");
                $(this).attr('data-password', 'true');
                $(this).addClass("show-password");
            } else {
                $(this).siblings("input").attr("type", "password");
                $(this).attr('data-password', 'false');
                $(this).removeClass("show-password");
            }
        });
    },

    Components.prototype.initMultiDropdown = function () {
        $('.dropdown-menu a.dropdown-toggle').on('click', function () {
            var dropdown = $(this).next('.dropdown-menu');
            var otherDropdown = $(this).parent().parent().find('.dropdown-menu').not(dropdown);
            otherDropdown.removeClass('show')
            otherDropdown.parent().find('.dropdown-toggle').removeClass('show')
            return false;
        });
    },

    //initilizing
    Components.prototype.init = function () {
        this.initTooltipPlugin(),
        this.initPopoverPlugin(),
        this.initToastPlugin(),
        this.initFormValidation(),
        this.initCounterUp(),
        this.initPeityCharts(),
        this.initKnob();
        this.initTippyTooltips();
        this.initShowPassword();
        this.initMultiDropdown();
    },

    $.Components = new Components, $.Components.Constructor = Components

}(window.jQuery),

function($) {
    "use strict";

    /**
    Portlet Widget
    */
    var Portlet = function() {
        this.$body = $("body"),
        this.$portletIdentifier = ".card",
        this.$portletCloser = '.card a[data-toggle="remove"]',
        this.$portletRefresher = '.card a[data-toggle="reload"]'
    };

    //on init
    Portlet.prototype.init = function() {
        // Panel closest
        var $this = this;
        $(document).on("click",this.$portletCloser, function (ev) {
            ev.preventDefault();
            var $portlet = $(this).closest($this.$portletIdentifier);
                var $portlet_parent = $portlet.parent();
            $portlet.remove();
            if ($portlet_parent.children().length == 0) {
                $portlet_parent.remove();
            }
        });

        // Panel Reload
        $(document).on("click",this.$portletRefresher, function (ev) {
            ev.preventDefault();
            var $portlet = $(this).closest($this.$portletIdentifier);
            // This is just a simulation, nothing is going to be reloaded
            $portlet.append('<div class="card-disabled"><div class="card-portlets-loader"><div class="spinner-border text-primary m-2" role="status"></div></div></div>');
            var $pd = $portlet.find('.card-disabled');
            setTimeout(function () {
                $pd.fadeOut('fast', function () {
                    $pd.remove();
                });
            }, 500 + 300 * (Math.random() * 5));
        });
    },
    //
    $.Portlet = new Portlet, $.Portlet.Constructor = Portlet
    
}(window.jQuery),


function ($) {
    'use strict';

    var App = function () {
        this.$body = $('body'),
        this.$window = $(window)
    };

    /** 
     * Initlizes the controls
    */
    App.prototype.initControls = function () {
        // remove loading
        setTimeout(function() {
            document.body.classList.remove('loading');
        }, 400);
        
        // Preloader
        $(window).on('load', function () {
            $('#status').fadeOut();
            $('#preloader').delay(350).fadeOut('slow');
        });

        $('[data-toggle="fullscreen"]').on("click", function (e) {
            e.preventDefault();
            $('body').toggleClass('fullscreen-enable');
            if (!document.fullscreenElement && /* alternative standard method */ !document.mozFullScreenElement && !document.webkitFullscreenElement) {  // current working methods
                if (document.documentElement.requestFullscreen) {
                    document.documentElement.requestFullscreen();
                } else if (document.documentElement.mozRequestFullScreen) {
                    document.documentElement.mozRequestFullScreen();
                } else if (document.documentElement.webkitRequestFullscreen) {
                    document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
                }
            } else {
                if (document.cancelFullScreen) {
                    document.cancelFullScreen();
                } else if (document.mozCancelFullScreen) {
                    document.mozCancelFullScreen();
                } else if (document.webkitCancelFullScreen) {
                    document.webkitCancelFullScreen();
                }
            }
        });
        document.addEventListener('fullscreenchange', exitHandler );
        document.addEventListener("webkitfullscreenchange", exitHandler);
        document.addEventListener("mozfullscreenchange", exitHandler);
        function exitHandler() {
            if (!document.webkitIsFullScreen && !document.mozFullScreen && !document.msFullscreenElement) {
                console.log('pressed');
                $('body').removeClass('fullscreen-enable');
            }
        }
    },

    //initilizing
    App.prototype.init = function () {
        $.Portlet.init();
        $.Components.init();

        this.initControls();

        // init layout
        this.layout = $.LayoutThemeApp;
        this.rightBar = $.RightBar;
        this.rightBar.layout = this.layout;
        this.layout.rightBar = this.rightBar;
    
        this.layout.init();
        this.rightBar.init(this.layout);
        

        // showing the sidebar on load if user is visiting the page first time only
        var bodyConfig = this.$body.data('layout');
        if (window.sessionStorage && bodyConfig && bodyConfig.hasOwnProperty('showRightSidebarOnPageLoad') && bodyConfig['showRightSidebarOnPageLoad']) {
            var alreadyVisited = sessionStorage.getItem("_MINTON_VISITED_");
            if (!alreadyVisited) {
                $.RightBar.toggleRightSideBar();
                sessionStorage.setItem("_MINTON_VISITED_", true);
            }
        }



        //Popovers
        var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
        var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
            return new bootstrap.Popover(popoverTriggerEl)
        })

        //Tooltips
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl, {

            })
        })



        //Toasts
        var toastElList = [].slice.call(document.querySelectorAll('.toast'))
        var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl)
        })

        // Toasts Placement
        var toastPlacement = document.getElementById("toastPlacement");
        if (toastPlacement) {
            document.getElementById("selectToastPlacement").addEventListener("change", function () {
                if (!toastPlacement.dataset.originalClass) {
                    toastPlacement.dataset.originalClass = toastPlacement.className;
                }
                toastPlacement.className = toastPlacement.dataset.originalClass + " " + this.value;
            });
        }

        //  RTL support js
        if(document.getElementById('bs-stylesheet').href.includes('rtl.min.css')){
            document.getElementsByTagName('html')[0].dir="rtl";
        }

    },

    $.App = new App, $.App.Constructor = App


}(window.jQuery),
//initializing main application module
function ($) {
    "use strict";
    $.App.init();
}(window.jQuery);

// Waves Effect
Waves.init();
