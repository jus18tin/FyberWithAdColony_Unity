//
//
// Copyright (c) 2015 Fyber. All rights reserved.
//
//

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSInteger, FYBURLEndpoint) {
    FYBURLEndpointActions,
    FYBURLEndpointInstalls,
    FYBURLEndpointVC,
    FYBURLEndpointOfferWall,
    FYBURLEndpointInterstitial,
    FYBURLEndpointBanner,
    FYBURLEndpointTracker,
    FYBURLEndpointBannerTracker,
    FYBURLEndpointRV,
    FYBURLEndpointAdaptersConfig,
    FYBURLEndpointVideoCache
};

@protocol FYBURLProvider<NSObject>

@required
- (NSString *)urlForEndpoint:(FYBURLEndpoint)endpointKey;
- (void)enableSSL:(BOOL)ssl;
- (void)enableSSL:(BOOL)ssl endpoint:(FYBURLEndpoint)endpointKey;

@end


@interface FYBBaseURLProvider : NSObject<FYBURLProvider>

+ (FYBBaseURLProvider *)sharedInstance;
- (NSString *)urlForEndpoint:(FYBURLEndpoint)endpointKey;

@property (strong, nonatomic) id<FYBURLProvider> customProvider;

- (void)restoreUrlsToDefault;

@end
