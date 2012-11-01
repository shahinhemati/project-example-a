window.EQHeight=function (slItem) {
    //thiet lap chieu cao 
        var max=0;
        $(slItem).each(function(){
            if(max<$(this).height()){
                max=$(this).height();
            }
        });
        $(slItem).each(function(){
            $(this).height(max);
        });
    };
jQuery(document).ready(function(){
    EQHeight(".item_img");
    EQHeight(".product-img");
    EQHeight(".news-one");
    EQHeight(".img_product");

  }
) 