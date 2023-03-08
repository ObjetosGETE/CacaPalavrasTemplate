var CheckMobile = {
    IsMobile : function()
    {
        return /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
    },

	IsIOSBrowser: function () {
        return (/iPhone|iPad|iPod/i.test(navigator.userAgent));
      },

    IsAndroidBrowser: function () {
        return (/Android/i.test(navigator.userAgent));
      },
};
mergeInto(LibraryManager.library, CheckMobile);