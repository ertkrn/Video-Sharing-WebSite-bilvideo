/**
 * Created by Alex on 12.08.2016.
 */
"use strict";
$( document ).ready(function() {



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Home page
    // Updates from Subscriptions Hover
    /*$(".avatars .col-lg-1").hover( function() {
            $(this).find(".note").show();
        }, function(){
            $(this).find(".note").hide();
        }
    );*/

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Home page
    // Popular Channels Hover
    /*$(".b-chanel").hover( function() {
            $(this).find(".hover").show();
        }, function(){
            $(this).find(".hover").hide();
        }
    );*/


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Home page
    // Video block hover
    var $plus = $( '<div class="plus"><i class="cvicon-cv-plus" aria-hidden="true"></i></div>' );
    var $plusDetails = $( '<div class="plus-details">\
                                        <ul >\
                                            <li><a href="#"><i class="cvicon-cv-watch-later" aria-hidden="true"></i> Daha Sonra İzle</a></li>\
                                            <li><a href="#"><i class="cvicon-cv-playlist" aria-hidden="true"></i> Oynatma Listesine Ekle</a></li>\
                                        </ul>\
                                    </div>' );

    $(".videolist .v-img").hover( function() {
            $(this).append($plus);
            $(".plus").hover( function() {
                    console.log("Plus hover");
                    $(this).parent().append($plusDetails);
                } , function(){

                }
            );

        } , function(){
            $(this).find(".plus").remove();
            $(this).find(".plus-details").remove();
        }
    );


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Header
    // Goto section
    $('[data-toggle="tooltip"]').tooltip();


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Header
    // Dropdown for "Pages" element on hover instead click.
    /*$('.pages').hover(function(){
        $('.dropdown-toggle', this).trigger('click');
		$('.dropdown-toggle', this).show();
	});*/


	//$('.pages').hover(function() { $(this).addClass('open'); }, function() { $(this).removeClass('open'); });



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Video Edit page
    // add color to checked checkboxes
    $('.edit-page input:checked').parent().css( "color", "#ea2c5a" );
    $('.edit-page input[type=checkbox]').on("click", function () {
       if ($(this).is(':checked')) {
        $(this).parent().css( "color", "#ea2c5a" );
       } else {
           $(this).parent().css( "color", "black" );
       }
    });


    var MYAPP = {
        initialize: function() {
            MYAPP.setUpListeners();
            MYAPP.ready();
        },

        setUpListeners: function() {
            var $document = $(document),
                $window = $(window),
                $tabs = $('.custom-tabs'),
                $activeTab = $tabs.find('.tabs-panel > .active'),
                vCategor_Right = $('.v-categories.side-menu .content-block .cb-content > .row > div:last-child'),
                vCategor_Left = $('.v-categories.side-menu .content-block .cb-content > .row > div:first-child'),
                $search_btn = $('.topsearch').find('.input-group-addon'),
                $search_btn_close = $('.topsearch-close'),
                $btn_menu = $('.btn-menu-toggle'),
                $btn_menu_close = $('.mobile-menu-close'),
                $menu = $('.mobile-menu'),
                $categories_mob = $('.mobile-menu-list'),
                $single_footer_switch = $('.single-v-footer-switch'),
                $channels_search = $('.channels-search'),
                $btn_transform = $('.search-group-transform'),
                $range_slider = $('.duration-range > input');

            var scroll_w = (function() {
                var scrollWidth,
                    $div = $('<div>').css({
                        overflowY: 'scroll',
                        width: '50px',
                        height: '50px',
                        visibility: 'hidden'
                    });

                $('body').append($div);
                scrollWidth = $div.get(0).offsetWidth - $div.get(0).clientWidth;
                $div.remove();

                return scrollWidth;
            })();

            $tabs.on('click', '.tabs-panel > a', function(e) {
                MYAPP.singlVideo.changeTab.call(this);
                e.preventDefault();
                e.stopPropagation();
                return false;
            });
            $(document).on('click', '.tab-popup-close', function(e) {
                $('.mfp-bg').trigger('click');

                e.preventDefault();
                return false;
            });
            $activeTab.trigger('click');

            //Clipboard
            if($('.btn-copy').length)
                new Clipboard('.btn-copy');

            $('.btn-color-toggle, .mobile-menu-btn-color').on('click', function() {
                if($('body').hasClass('light')) {
                    $('body').removeClass('light').addClass('dark');
                    $(this).find('img').attr('src', 'images/icon_bulb_dark.png');
                } else { if($('body').hasClass('dark'))
                    $('body').removeClass('dark').addClass('light');
                    $(this).find('img').attr('src', 'images/icon_bulb_light.png');
                }
            });

            function align_categor_col() {
                vCategor_Left.removeAttr('style');
                if(vCategor_Left.innerHeight() <= vCategor_Right.innerHeight()) {
                    vCategor_Left.css({'height': vCategor_Right.innerHeight()});
                }
            };

            function add_categor_bg() {
                var bg_add = $('.v-categories.side-menu .bg-add'),
                    vCategor_Left_posL = vCategor_Left.get(0).getBoundingClientRect().left;

                bg_add.css({
                    height: vCategor_Left.innerHeight(),
                    width: vCategor_Left_posL + 'px',
                    left: '-' + vCategor_Left_posL + 'px'
                });
            };

            if($('.v-categories.side-menu').length) {
                align_categor_col();
                add_categor_bg();
            }

            $(window).resize(function() {
                if($('.v-categories.side-menu').length) {
                    align_categor_col();
                    add_categor_bg();
                }
            });

            $('.u-form input[type="checkbox"]').on('change', function() {
                var $this = $(this),
                    checkboxDiv = $(this).parents('div.checkbox');

                if($this.next().css('display') === 'block'){
                    checkboxDiv.addClass('checked');
                }else{
                    checkboxDiv.removeClass('checked');
                }

            });

            $search_btn.on('click', function() {
                var wind_w = window.innerWidth;

                if(wind_w < 768) {
                    $('.navbar-container').addClass('search-open');
                }
            });

            $search_btn_close.on('click', function() {
                $('.navbar-container').removeClass('search-open');
            });

            $btn_menu.on('click', function(e) {
                var wind_w = window.innerWidth;

                if(wind_w < 768) {
                    if(!$menu.hasClass('open')) {
                        $('body').addClass('ovf--hidden').css({ paddingRight: scroll_w });

                        $menu.addClass('open');
                    } else {
                        $('body').removeClass('ovf--hidden').removeAttr('style');

                        $menu.removeClass('open');
                    }
                }

                e.preventDefault();
                return false;
            });

            $btn_menu_close.on('click', function(e) {
                $('body').removeClass('ovf--hidden').removeAttr('style');

                $menu.removeClass('open');

                e.preventDefault();
                return false;
            });

            $categories_mob.find('li a').on('click', function(e) {
                var wind_w = window.innerWidth;

                if(wind_w < 768) {
                    var $this = $(this),
                        $ul = $this.parent().find('> ul');

                    if($ul.length) {
                        $ul.slideToggle();

                        e.stopPropagation();
                        e.preventDefault();
                        return false;
                    }
                }
            });

            $single_footer_switch.find('> a').on('click', function(e) {
                var wind_w = window.innerWidth;

                if(wind_w < 768) {
                    var $this = $(this),
                        $btn_elem_toggle = $($this.attr('data-toggle')),
                        $btns = $this.parent().find('> a');

                    $btns.each(function() {
                        var $elem_toggle = $($(this).removeClass('active').attr('data-toggle'));

                        $elem_toggle.hide();
                    });

                    $this.addClass('active');
                    $btn_elem_toggle.show();
                }

                e.preventDefault();
                return false;
            });

            $(function() {
                $single_footer_switch.find('a.active').trigger('click');
            });

            $channels_search.find('i').on('click', function() {
                var $this = $(this),
                    $head = $this.parents('.cb-header');

                $head.toggleClass('channels-search-open');
            });

            $btn_transform.find('.s-s-title').on('click', function() {
                var wind_w = window.innerWidth;

                if(wind_w < 768) {
                    $(this).parent().toggleClass('open');
                }
            });

            if($range_slider.length) {
                $range_slider.ionRangeSlider({
                    type: "double",
                    min: 0,
                    max: 40,
                    from: 0,
                    to: 20,
                    step: 10,
                    hide_min_max: true,
                    hide_from_to: true,
                    grid: true
                });
            }
            
            $(window).on('load resize', function() {
                $menu.removeClass('open');
                $('body').removeClass('ovf--hidden').removeAttr('style');
            });
        },

        singlVideo: {
            changeTab: function() {
                var wind_w = window.innerWidth,
                    $this = $(this),
                    $dataTab = $this.attr('data-tab');

                if(wind_w > 767 || $this.attr('data-tab') === 'tab-1') {
                    var $tabs = $this.parents('.custom-tabs').find('.tabs-content').children(),
                        i = 0;

                    for(; i < $tabs.length; i++) {
                        if($tabs.eq(i).hasClass($dataTab)) {
                            $tabs.removeClass('active').eq(i).addClass('active');
                            $this.parent().children().removeClass('active');
                            $this.addClass('active');
                            return;
                        }
                    }
                } else {
                    var selector = '.' + $dataTab + ' .tab-popup';

                    $.magnificPopup.open({
                        mainClass: 'mfp-with-zoom',
                        removalDelay: 300,
                        closeMarkup: '<button title="%title%" type="button" class="mfp-close icon-Cancel"></button>',
                        items: [
                            {
                                src: '.' + $dataTab + ' .tab-popup',
                                type: 'inline',
                            }
                        ]
                    });
                }
            }
        },

        ready: function() {
            if($('video').length) {
                $('video').mediaelementplayer({
                    alwaysShowControls: false,
                    videoVolume: 'horizontal',
                    features: ['playpause','progress','current','duration','tracks','volume','fullscreen'],
                    enableKeyboard: true,
                    pauseOtherPlayers: true,
                    enableAutosize: true
                });
            }
        }
    };

    MYAPP.initialize();

});